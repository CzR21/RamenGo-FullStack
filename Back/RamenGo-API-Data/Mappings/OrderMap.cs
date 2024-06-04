using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RamenGo_API_Domain.Entities;
using RamenGo_API_Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RamenGo_API_Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("tb_order");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.TypeStatus)
               .HasConversion(
                   v => v.ToString(),
                   v => (TypeStatus)Enum.Parse(typeof(TypeStatus), v))
               .IsRequired()
               .HasColumnType("varchar(255)");

            builder.HasOne(x => x.Protein)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ProteinId);

            builder.HasOne(x => x.Broth)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.BrothId);
        }
    }
}
