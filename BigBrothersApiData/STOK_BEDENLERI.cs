using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_BEDENLERI
    {
        public System.Guid bed_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> bed_pasif_fl { get; set; }
        public string? bed_special1 { get; set; }
        public string? bed_special2 { get; set; }
        public string? bed_special3 { get; set; }
        public required string bed_kod { get; set; }
        public string? bed_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_BEDENLERIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_BEDENLERI>
        {
            public void Configure(EntityTypeBuilder<STOK_BEDENLERI> builder)
            {
                builder
                    .HasIndex(p => new { p.bed_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.bed_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.bed_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.bed_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.bed_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.bed_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_BEDENLERI)
                    .HasForeignKey(x => x.sto_beden_kodu)
                    .HasPrincipalKey(x => x.bed_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}