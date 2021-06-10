using Microsoft.EntityFrameworkCore;
using SSAI.Entity.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSAI.Data
{
    public class SSAIDBOrderContext : DbContext
    {
        public SSAIDBOrderContext(DbContextOptions<SSAIDBOrderContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //OrderProduct
            builder.Entity<OrderProduct>(act =>
            {
                act.HasOne(field => field.FkOrderNavigation)
                .WithMany(fk => fk.OrderProducts)
                .HasForeignKey(fk => fk.FkOrder)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
    }
}
