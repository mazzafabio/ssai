using Microsoft.EntityFrameworkCore;
using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Data
{
    public class SSAIDBProductContext : DbContext
    {
        public SSAIDBProductContext(DbContextOptions<SSAIDBProductContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Product
            builder.Entity<Product>(act =>
            {
                act
                .HasIndex(x => new { x.Name, x.Description })
                .IsUnique();
            });
        }


        public DbSet<Product> Products { get; set; }
    }
}
