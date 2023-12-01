using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_RENKLERI
    {
        public System.Guid ren_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> ren_pasif_fl { get; set; }
        public string? ren_special1 { get; set; }
        public string? ren_special2 { get; set; }
        public string? ren_special3 { get; set; }
        public required string ren_kod { get; set; }
        public string? ren_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_RENKLERIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_RENKLERI>
        {
            public void Configure(EntityTypeBuilder<STOK_RENKLERI> builder)
            {
                builder
                    .HasIndex(p => new { p.ren_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.ren_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.ren_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.ren_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.ren_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.ren_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_RENKLERI)
                    .HasForeignKey(x => x.sto_renk_kodu)
                    .HasPrincipalKey(x => x.ren_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}