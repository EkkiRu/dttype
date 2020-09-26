using Castle.Core.Configuration;
using DataTypes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTypes.Data
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Files> Files { get; set; }
        public DbSet<Folder> Folders { get; set; }

        private string connectionString;
        public ApplicationContext(string connectionString)
        {
            this.connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
