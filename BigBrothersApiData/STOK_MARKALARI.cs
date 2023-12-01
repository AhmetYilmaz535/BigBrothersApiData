using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_MARKALARI
    {
        public System.Guid mar_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> mar_pasif_fl { get; set; }
        public string? mar_special1 { get; set; }
        public string? mar_special2 { get; set; }
        public string? mar_special3 { get; set; }
        public required string mar_kod { get; set; }
        public string? mar_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_MARKALARIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_MARKALARI>
        {
            public void Configure(EntityTypeBuilder<STOK_MARKALARI> builder)
            {
                builder
                    .HasIndex(p => new { p.mar_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.mar_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.mar_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.mar_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.mar_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.mar_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_MARKALARI)
                    .HasForeignKey(x => x.sto_marka_kodu)
                    .HasPrincipalKey(x => x.mar_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}