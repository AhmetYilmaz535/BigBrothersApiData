using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_MODELLERI
    {
        public System.Guid mod_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> mod_pasif_fl { get; set; }
        public string? mod_special1 { get; set; }
        public string? mod_special2 { get; set; }
        public string? mod_special3 { get; set; }
        public required string mod_kod { get; set; }
        public string? mod_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_MODELLERIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_MODELLERI>
        {
            public void Configure(EntityTypeBuilder<STOK_MODELLERI> builder)
            {
                builder
                    .HasIndex(p => new { p.mod_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.mod_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.mod_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.mod_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.mod_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.mod_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_MODELLERI)
                    .HasForeignKey(x => x.sto_model_kodu)
                    .HasPrincipalKey(x => x.mod_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}