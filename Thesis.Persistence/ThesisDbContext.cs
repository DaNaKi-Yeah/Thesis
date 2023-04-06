using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thesis.Domain.Entities.Models;

namespace Thesis.Persistence
{
    public class ThesisDbContext : DbContext
    {
        public ThesisDbContext(DbContextOptions<ThesisDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; }
        public DbSet<News> News { get; }
        public DbSet<Department> Departments { get; }
        public DbSet<UserNews> UserNews { get; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserNews>().HasKey(un => new { un.UserID, un.NewsID });
        }
    }
}
