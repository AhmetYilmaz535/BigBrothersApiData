using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BigBrothersApiData
{
    public class STOK_SEZONLARI
    {
        public System.Guid sez_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> sez_pasif_fl { get; set; }
        public string? sez_special1 { get; set; }
        public string? sez_special2 { get; set; }
        public string? sez_special3 { get; set; }
        public required string sez_kod { get; set; }
        public string? sez_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_SEZONLARIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_SEZONLARI>
        {
            public void Configure(EntityTypeBuilder<STOK_SEZONLARI> builder)
            {
                builder
                    .HasIndex(p => new { p.sez_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.sez_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.sez_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.sez_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.sez_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.sez_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_SEZONLARI)
                    .HasForeignKey(x => x.sto_sezon_kodu)
                    .HasPrincipalKey(x => x.sez_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}