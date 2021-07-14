using Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class ContextBase : IdentityDbContext<IdentityUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        { 
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<CompraUsuario> CompraUsuario { get; set; }
        public DbSet<IdentityUser> IdentityUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConnectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>().ToTable("AspNetUsers").HasKey(t => t.Id);

            base.OnModelCreating(builder);
        }

        private string GetStringConnectionConfig()
        {
            string strConn = "Data Source=DESKTOP-AHRHU5B;Initial Catalog=ecommerce;Integrated Security=SSPI;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";            
            return strConn;
        }
    }
}
