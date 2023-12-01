using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBrothersApiData
{
    public class STOK_ANA_GRUPLAR
    {
        [Key]
        public System.Guid san_Guid { get; set; }
        public required Guid Firma_Guid { get; set; }
        public Nullable<bool> san_pasif_fl { get; set; }
        public string? san_special1 { get; set; }
        public string? san_special2 { get; set; }
        public string? san_special3 { get; set; }
        public required string san_kod { get; set; }
        public string? san_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();
        public ICollection<STOK_ALT_GRUPLAR> STOK_ALT_GRUPLARs { get; set; } = new HashSet<STOK_ALT_GRUPLAR>();


        public class STOK_ANA_GRUPLAREntityTypeConfiguration : IEntityTypeConfiguration<STOK_ANA_GRUPLAR>
        {
            public void Configure(EntityTypeBuilder<STOK_ANA_GRUPLAR> builder)
            {
                builder
                    .HasIndex(p => new { p.san_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.san_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.san_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.san_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.san_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.san_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_ANA_GRUPLAR)
                    .HasForeignKey(x => x.sto_anagrup_kod)
                    .HasPrincipalKey(x => x.san_Guid)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(x => x.STOK_ALT_GRUPLARs)
                    .WithOne(x => x.STOK_ANA_GRUPLAR)
                    .HasForeignKey(x => x.salt_ana_grup)
                    .HasPrincipalKey(x => x.san_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }

    }
}
