using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBrothersApiData
{
    public class STOK_SEKTORLERI
    {
        public System.Guid sktr_Guid { get; set; }
        public required Guid Firma_Guid { get; set; }
        public Nullable<bool> sktr_pasif_fl { get; set; }
        public string? sktr_special1 { get; set; }
        public string? sktr_special2 { get; set; }
        public string? sktr_special3 { get; set; }
        public required string sktr_kod { get; set; }
        public string? sktr_isim { get; set; }


        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();


        public class STOK_SEKTORLERIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_SEKTORLERI>
        {
            public void Configure(EntityTypeBuilder<STOK_SEKTORLERI> builder)
            {
                builder
                    .HasIndex(p => new { p.sktr_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.sktr_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.sktr_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.sktr_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.sktr_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.sktr_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_SEKTORLERI)
                    .HasForeignKey(x => x.sto_sektor_kodu)
                    .HasPrincipalKey(x => x.sktr_Guid)
                    .OnDelete(DeleteBehavior.Restrict);

                
            }
        }
    }
}
