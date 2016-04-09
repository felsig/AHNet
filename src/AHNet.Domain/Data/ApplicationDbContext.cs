﻿using AHNet.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;

namespace AHNet.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private IConfiguration _configuration;

        public ApplicationDbContext(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration["Data:DefaultConnection:ConnectionString"];
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
