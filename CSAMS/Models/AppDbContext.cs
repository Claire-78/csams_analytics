using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.IO;

namespace CSAMS.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Fields> Fields { get; set; }
        public DbSet<Forms> Forms { get; set; }
        public DbSet<PeerReviews> PeerReviews { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Submissions> Submissions { get; set; }
        public DbSet<UserCourses> UserCourses { get; set; }
        public DbSet<UserReviews> UserReviews { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSubmissions> UserSubmissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            if (path.Contains("bin"))
            optionsBuilder.UseSqlite($"Data Source={path.Substring(0, path.IndexOf("bin"))}Data/csams.sqlite");
        }
    }

}
