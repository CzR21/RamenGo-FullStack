using Microsoft.EntityFrameworkCore;
using RamenGo_API_Data.Mappings;
using RamenGo_API_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Data.Context
{
    public class RamenContext : DbContext
    {
        public RamenContext(DbContextOptions<RamenContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Broth> Broths{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<Protein> Proteins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BrothMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new ProteinMap());
        }
    }
}
