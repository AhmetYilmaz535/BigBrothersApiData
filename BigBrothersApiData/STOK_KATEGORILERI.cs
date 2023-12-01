using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;

namespace BigBrothersApiData
{
    public class STOK_KATEGORILERI
    {
        [Key]
        public System.Guid ktg_Guid { get; set; }
        public required Guid Firma_Guid { get; set; }
        public Nullable<bool> ktg_pasif_fl { get; set; }
        public string? ktg_special1 { get; set; }
        public string? ktg_special2 { get; set; }
        public string? ktg_special3 { get; set; }
        public required string ktg_kod { get; set; }
        public string? ktg_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();


        public class STOK_KATEGORILERIEntityTypeConfiguration: IEntityTypeConfiguration<STOK_KATEGORILERI>
        {
           public void Configure(EntityTypeBuilder<STOK_KATEGORILERI> builder)
            {
                builder
                    .HasIndex(p=> new { p.ktg_kod,p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.ktg_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.ktg_isim)
                    .HasMaxLength(150);
                    builder
                    .Property(p => p.ktg_special1)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.ktg_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.ktg_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_KATEGORILERI)
                    .HasForeignKey(x => x.sto_kategori_kodu)
                    .HasPrincipalKey(x => x.ktg_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }

    }
}
