using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBrothersApiData
{
    public class STOK_REYONLAR
    {
        public System.Guid ryn_Guid { get; set; }
        public required Guid Firma_Guid { get; set; }
        public Nullable<bool> ryn_pasif_fl { get; set; }
        public string? ryn_special1 { get; set; }
        public string? ryn_special2 { get; set; }
        public string? ryn_special3 { get; set; }
        public required string ryn_kod { get; set; }
        public string? ryn_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_REYONLAREntityTypeConfiguration : IEntityTypeConfiguration<STOK_REYONLAR>
        {
            public void Configure(EntityTypeBuilder<STOK_REYONLAR> builder)
            {
                builder
                    .HasIndex(p => new { p.ryn_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.ryn_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.ryn_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.ryn_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.ryn_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.ryn_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_REYONLAR)
                    .HasForeignKey(x => x.sto_reyon_kodu)
                    .HasPrincipalKey(x => x.ryn_Guid)
                    .OnDelete(DeleteBehavior.Restrict);


            }
        }
    }
}
