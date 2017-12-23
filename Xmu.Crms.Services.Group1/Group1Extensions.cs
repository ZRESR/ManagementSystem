using Xmu.Crms.Services.Group1;
using Xmu.Crms.Services.Group1.Dao;
using Xmu.Crms.Shared.Service;

namespace Microsoft.Extensions.DependencyInjection
{ 
    public static class Group1Extensions
    {
        // 为每一个你写的Service写一个这样的函数，把 LoginService 替换为你实现的 Service
        public static IServiceCollection AddGroup1UserService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<IUserService, UserService>();
        }
        //school 注入
        public static IServiceCollection AddGroup1SchoolService(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<ISchoolService, SchoolService>();
        }
        public static IServiceCollection AddGroup1SchoolDao(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<ISchoolDao, SchoolDao>();
        }

    }
}
