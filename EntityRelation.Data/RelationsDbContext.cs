using EntityRelation.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityRelation.Data
{
    public class RelationsDbContext : DbContext
    {
        public RelationsDbContext(DbContextOptions<RelationsDbContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
