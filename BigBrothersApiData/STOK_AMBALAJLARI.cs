using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_AMBALAJLARI
    {
        public System.Guid amb_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> amb_pasif_fl { get; set; }
        public string? amb_special1 { get; set; }
        public string? amb_special2 { get; set; }
        public string? amb_special3 { get; set; }
        public required string amb_kod { get; set; }
        public string? amb_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_AMBALAJLARIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_AMBALAJLARI>
        {
            public void Configure(EntityTypeBuilder<STOK_AMBALAJLARI> builder)
            {
                builder
                    .HasIndex(p => new { p.amb_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.amb_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.amb_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.amb_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.amb_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.amb_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_AMBALAJLARI)
                    .HasForeignKey(x => x.sto_ambalaj_kodu)
                    .HasPrincipalKey(x => x.amb_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}