using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_api_vertical.Domain;
using backend_api_vertical.Domain.Entities;
using backend_api_vertical.Features.Repository.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend_api_vertical.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Game> Games { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfigurations());
        }

    }
}