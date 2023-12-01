using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_CINSI
    {
        public System.Guid cin_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> cin_pasif_fl { get; set; }
        public string? cin_special1 { get; set; }
        public string? cin_special2 { get; set; }
        public string? cin_special3 { get; set; }
        public required string cin_kod { get; set; }
        public string? cin_isim { get; set; }

        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_CINSIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_CINSI>
        {
            public void Configure(EntityTypeBuilder<STOK_CINSI> builder)
            {
                builder
                    .HasIndex(p => new { p.cin_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.cin_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.cin_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.cin_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.cin_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.cin_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_CINSI)
                    .HasForeignKey(x => x.sto_cins)
                    .HasPrincipalKey(x => x.cin_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}