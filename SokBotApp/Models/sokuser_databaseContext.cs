using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SokBotApp.Models
{
    public partial class sokuser_databaseContext : DbContext
    {
        public sokuser_databaseContext()
        {
        }

        public sokuser_databaseContext(DbContextOptions<sokuser_databaseContext> options)
            : base(options)
        {
        }
        
        public virtual DbSet<SokGroup> SokGroups { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        public virtual DbSet<SoftVersion> SoftVersions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=127.0.0.1;port=3307;database=sokuser_database;uid=sokuser_sok;pwd=M4d8s3w9", ServerVersion.Parse("10.6.9-mariadb"));
            }
        }


    }
}
