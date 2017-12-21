using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xmu.Crms.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Http;
using System.Threading;
using Xmu.Crms.Connections;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Collections.ObjectModel;
using Microsoft.Net.Http.Headers;
using Microsoft.Extensions.Logging;

namespace Xmu.Crms
{
    public class Startup
    {
        private static string _connString = string.Empty;

        private static SymmetricSecurityKey _signingKey;

        private static TokenValidationParameters _tokenValidationParameters;

        public static Func<IServiceCollection, IServiceCollection> ConfigureCrmsServices { get; set; } = c => c;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            //读取appsettings配置文件必须设置
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureCrmsServices.Invoke(services);
            services.Configure<JwtSettings>(Configuration.GetSection("JwtSettings"));
            var jwtSettings = new JwtSettings();
            Configuration.Bind("JwtSettings", jwtSettings);

            // JWT参数,生成Key
            _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.ServerSecretKey));

            //验证header中的JWT
            _tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                //JWT issuer,audience(订阅者 not claim
                ValidateAudience = false,
                ValidateActor = false,
                ValidateIssuer = false
            };

            services.AddSingleton(
                new JwtHeader(new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256)));
            // 登录与鉴权
            services
                .AddAuthentication(options => { options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; })
                .AddJwtBearer(
                    options =>
                    {
                        options.Events = new JwtBearerEvents();
                        options.TokenValidationParameters = _tokenValidationParameters;
                        options.Events.OnChallenge += async eventContext =>
                        {
                            if (eventContext.AuthenticateFailure != null)
                            {
                                if (string.IsNullOrEmpty(eventContext.Error) &&
                                    string.IsNullOrEmpty(eventContext.ErrorDescription) &&
                                    string.IsNullOrEmpty(eventContext.ErrorUri))
                                {
                                    eventContext.Response.Headers.Append(HeaderNames.WWWAuthenticate,
                                        eventContext.Options.Challenge);
                                }
                                else
                                {
                                    // https://tools.ietf.org/html/rfc6750#section-3.1
                                    // WWW-Authenticate: Bearer realm="example", error="invalid_token", error_description="The access token expired"
                                    var builder = new StringBuilder(eventContext.Options.Challenge);
                                    if (eventContext.Options.Challenge.IndexOf(" ", StringComparison.Ordinal) > 0)
                                    {
                                        // Only add a comma after the first param, if any
                                        builder.Append(',');
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.Error))
                                    {
                                        builder.Append(" error=\"");
                                        builder.Append(eventContext.Error);
                                        builder.Append("\"");
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.ErrorDescription))
                                    {
                                        if (!string.IsNullOrEmpty(eventContext.Error))
                                        {
                                            builder.Append(",");
                                        }

                                        builder.Append(" error_description=\"");
                                        builder.Append(eventContext.ErrorDescription);
                                        builder.Append('\"');
                                    }
                                    if (!string.IsNullOrEmpty(eventContext.ErrorUri))
                                    {
                                        if (!string.IsNullOrEmpty(eventContext.Error) ||
                                            !string.IsNullOrEmpty(eventContext.ErrorDescription))
                                        {
                                            builder.Append(",");
                                        }

                                        builder.Append(" error_uri=\"");
                                        builder.Append(eventContext.ErrorUri);
                                        builder.Append('\"');
                                    }

                                    eventContext.Response.Headers.Append(HeaderNames.WWWAuthenticate,
                                        builder.ToString());
                                }
                                eventContext.Response.StatusCode = 401;
                                eventContext.Response.Headers.Append(HeaderNames.ContentType, "application/json");

                                eventContext.HandleResponse();
                                var msg = "登录无效";

                                var ex = eventContext.AuthenticateFailure;
                                var exceptions = new ReadOnlyCollection<Exception>(new[] { ex });
                                if (ex is AggregateException agEx)
                                {
                                    exceptions = agEx.InnerExceptions;
                                }
                                if (exceptions.Select(e => e is SecurityTokenExpiredException).Any())
                                {
                                    msg = "登录已过期，请重新登录";
                                }
                                // 检查更多错误情况
                                var json = $"{{\"msg\": \"{msg}\"}}";
                                var b = Encoding.UTF8.GetBytes(json);
                                await eventContext.Response.Body.WriteAsync(b, 0, b.Length);
                            }
                        };
                    });

            var connection = @"Server=127.0.0.1; database=ooad; uid=root; pwd=123456; ";
            services.AddDbContext<DataContext>(options => options.UseMySql(connection));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            app.UseWebSockets();
            app.UseMiddleware<ChatWebSocketMiddleware>();
            //使用JWT Bear服务
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
