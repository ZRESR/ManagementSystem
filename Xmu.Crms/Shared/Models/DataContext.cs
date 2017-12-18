using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xmu.Crms.Shared.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Attendance> Attendence { get; set; }
        public DbSet<ClassInfo> ClassInfo { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseSelection> CourseSelection { get; set; }
        public DbSet<FixGroup> FixGroup { get; set; }
        public DbSet<FixGroupMember> FixGroupMember  { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<School> School { get; set; }
        public DbSet<Seminar> Seminar { get; set; }
        public DbSet<SeminarGroup> SeminarGroup { get; set; }
        public DbSet<SeminarGroupMember> SeminarGroupMember { get; set; }
        public DbSet<SeminarGroupTopic> SeminarGroupTopic { get; set; }
        public DbSet<StudentScoreGroup> StudentScoreGroup { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
