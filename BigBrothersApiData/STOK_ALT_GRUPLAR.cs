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
    public class STOK_ALT_GRUPLAR
    {
        [Key]
        public System.Guid salt_Guid { get; set; }
        public required Guid Firma_Guid { get; set; }
        public Nullable<bool> salt_pasif_fl { get; set; }
        public string? salt_special1 { get; set; }
        public string? salt_special2 { get; set; }
        public string? salt_special3 { get; set; }
        public required string salt_kod { get; set; }
        public string? salt_isim { get; set; }
        public Guid salt_ana_grup { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();
        public required STOK_ANA_GRUPLAR STOK_ANA_GRUPLAR { get; set; }


        public class STOK_ALT_GRUPLAREntityTypeConfiguration : IEntityTypeConfiguration<STOK_ALT_GRUPLAR>
        {
            public void Configure(EntityTypeBuilder<STOK_ALT_GRUPLAR> builder)
            {
                builder
                    .HasIndex(p => new { p.Firma_Guid, p.salt_ana_grup, p.salt_kod })
                    .IsUnique();
                builder
                    .Property(p => p.salt_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.salt_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.salt_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.salt_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.salt_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_ALT_GRUPLAR)
                    .HasForeignKey(x => x.sto_altgrup_kod)
                    .HasPrincipalKey(x => x.salt_kod)
                    .OnDelete(DeleteBehavior.Restrict);
                
            }
        }

    }
}
