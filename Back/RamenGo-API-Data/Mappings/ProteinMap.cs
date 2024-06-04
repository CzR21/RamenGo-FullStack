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
    public class ProteinMap : IEntityTypeConfiguration<Protein>
    {
        public void Configure(EntityTypeBuilder<Protein> builder)
        {
            builder.ToTable("tb_protein");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(c => c.TypeStatus)
               .HasConversion(
                   v => v.ToString(),
                   v => (TypeStatus)Enum.Parse(typeof(TypeStatus), v))
               .IsRequired()
               .HasColumnType("varchar(255)");

            builder.Property(x => x.Name);
            builder.Property(x => x.Description);
            builder.Property(x => x.Price);
            builder.Property(x => x.ImageActive);
            builder.Property(x => x.ImageInactive);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Protein)
                .HasForeignKey(x => x.ProteinId);
        }
    }
}
