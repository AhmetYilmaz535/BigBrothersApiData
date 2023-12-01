using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigBrothersApiData
{
    public class STOK_MUHASEBE_GRUPLARI
    {
        public System.Guid mhg_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> mhg_pasif_fl { get; set; }
        public string? mhg_special1 { get; set; }
        public string? mhg_special2 { get; set; }
        public string? mhg_special3 { get; set; }
        public required string mhg_kod { get; set; }
        public string? mhg_isim { get; set; }
        public string? mhg_muh_kod { get; set; }
        public string? mhg_iade_muh_kod { get; set; }
        public string? mhg_YurtIciSatMuhK { get; set; }
        public string? mhg_SatIadeMuhKod { get; set; }
        public string? mhg_SatIskMuhKod { get; set; }
        public string? mhg_Al_IskMKod { get; set; }
        public string? mhg_SatMalMuhKod { get; set; }
        public string? mhg_YurtDisiSatMuh { get; set; }
        public string? mhg_ilavemasmuhkod { get; set; }
        public string? mhg_yatirimtesmuhkod { get; set; }
        public string? mhg_depsatmuhkod { get; set; }
        public string? mhg_depsatmalmuhkod { get; set; }
        public string? mhg_bagortsatmuhkod { get; set; }
        public string? mhg_bagortsatIadmuhkod { get; set; }
        public string? mhg_bagortsatIskmuhkod { get; set; }
        public string? mhg_satfiyfarkmuhkod { get; set; }
        public string? mhg_yurtdisisatmalmuhkod { get; set; }
        public string? mhg_bagortsatmalmuhkod { get; set; }
        public string? mhg_sifirbedsatmalmuhkod { get; set; }
        public string? mhg_ihrackayitlisatismuhkod { get; set; }
        public string? mhg_ihrackayitlisatismaliyetimuhkod { get; set; }
        public string? mhg_ufrsfark_kod { get; set; }
        public string? mhg_iade_ufrsfark_kod { get; set; }
        public string? mhg_yurticisat_ufrsfark_kod { get; set; }
        public string? mhg_satiade_ufrsfark_kod { get; set; }
        public string? mhg_satisk_ufrsfark_kod { get; set; }
        public string? mhg_alisk_ufrsfark_kod { get; set; }
        public string? mhg_satmal_ufrsfark_kod { get; set; }
        public string? mhg_yurtdisisat_ufrsfark_kod { get; set; }
        public string? mhg_ilavemas_ufrsfark_kod { get; set; }
        public string? mhg_yatirimtes_ufrsfark_kod { get; set; }
        public string? mhg_depsat_ufrsfark_kod { get; set; }
        public string? mhg_depsatmal_ufrsfark_kod { get; set; }
        public string? mhg_bagortsat_ufrsfark_kod { get; set; }
        public string? mhg_bagortsatiade_ufrsfark_kod { get; set; }
        public string? mhg_bagortsatisk_ufrsfark_kod { get; set; }
        public string? mhg_satfiyfark_ufrsfark_kod { get; set; }
        public string? mhg_yurtdisisatmal_ufrsfark_kod { get; set; }
        public string? mhg_bagortsatmal_ufrsfark_kod { get; set; }
        public string? mhg_sifirbedsatmal_ufrsfark_kod { get; set; }
        public string? mhg_uretimmaliyet_ufrsfark_kod { get; set; }
        public string? mhg_uretimkapasite_ufrsfark_kod { get; set; }
        public string? mhg_degerdusuklugu_ufrs_kod { get; set; }
        public ICollection<STOKLAR> STOKLARs { get; set; } = new HashSet<STOKLAR>();

        public class STOK_MUHASEBE_GRUPLARIEntityTypeConfiguration : IEntityTypeConfiguration<STOK_MUHASEBE_GRUPLARI>
        {
            public void Configure(EntityTypeBuilder<STOK_MUHASEBE_GRUPLARI> builder)
            {
                builder
                    .HasIndex(p => new { p.mhg_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.mhg_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.mhg_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.mhg_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.mhg_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.mhg_special3)
                    .HasMaxLength(8);

                builder.HasMany(x => x.STOKLARs)
                    .WithOne(x => x.STOK_MUHASEBE_GRUPLARI)
                    .HasForeignKey(x => x.sto_muhgrup_kodu)
                    .HasPrincipalKey(x => x.mhg_Guid)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        }
    }
}