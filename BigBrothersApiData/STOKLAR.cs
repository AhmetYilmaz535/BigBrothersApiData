using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBrothersApiData
{
    public class STOKLAR
    {
        public System.Guid sto_Guid { get; set; }
        public Guid Firma_Guid { get; set; }
        public Nullable<bool> sto_pasif_fl { get; set; }
        public string? sto_special1 { get; set; }
        public string? sto_special2 { get; set; }
        public string? sto_special3 { get; set; }
        public required string sto_kod { get; set; }
        public string? sto_isim { get; set; }
        public string? sto_kisa_ismi { get; set; }
        public string? sto_yabanci_isim { get; set; }
        public Guid sto_cins { get; set; }
        public Guid sto_birim { get; set; }
        public Guid sto_kategori_kodu { get; set; }
        public Guid sto_anagrup_kod { get; set; }
        public Guid sto_altgrup_kod { get; set; }
        public Guid sto_sektor_kodu { get; set; }
        public Guid sto_reyon_kodu { get; set; }
        public Guid sto_muhgrup_kodu { get; set; }
        public Guid sto_ambalaj_kodu { get; set; }
        public Guid sto_marka_kodu { get; set; }
        public Guid sto_beden_kodu { get; set; }
        public Guid sto_renk_kodu { get; set; }
        public Guid sto_model_kodu { get; set; }
        public Guid sto_sezon_kodu { get; set; }
        public Guid sto_GtipNo { get; set; }
        public string? sto_resim { get; set; }
       
        public STOK_KATEGORILERI? STOK_KATEGORILERI { get; set; }   
        public STOK_ANA_GRUPLAR? STOK_ANA_GRUPLAR { get; set; }
        public STOK_ALT_GRUPLAR? STOK_ALT_GRUPLAR { get; set; }
        public STOK_SEKTORLERI? STOK_SEKTORLERI { get; set; }
        public STOK_REYONLAR? STOK_REYONLAR { get; set; }
        public STOK_MUHASEBE_GRUPLARI? STOK_MUHASEBE_GRUPLARI { get; set; }
        public STOK_AMBALAJLARI? STOK_AMBALAJLARI { get; set; }
        public STOK_MARKALARI? STOK_MARKALARI { get; set; }
        public STOK_BEDENLERI? STOK_BEDENLERI { get; set; }
        public STOK_RENKLERI? STOK_RENKLERI { get; set; }
        public STOK_MODELLERI? STOK_MODELLERI { get; set; }
        public STOK_SEZONLARI? STOK_SEZONLARI { get; set; }
        public STOK_CINSI? STOK_CINSI { get; set; }


        public class STOKLAREntityTypeConfiguration : IEntityTypeConfiguration<STOKLAR>
        {
            public void Configure(EntityTypeBuilder<STOKLAR> builder)
            {
                builder
                    .HasIndex(p => new { p.sto_kod, p.Firma_Guid })
                    .IsUnique();
                builder
                    .Property(p => p.sto_kod)
                    .HasMaxLength(50)
                    .IsRequired();
                builder
                    .Property(p => p.sto_isim)
                    .HasMaxLength(150);
                builder
                .Property(p => p.sto_special1)
                .HasMaxLength(8);
                builder
                    .Property(p => p.sto_special2)
                    .HasMaxLength(8);
                builder
                    .Property(p => p.sto_special3)
                    .HasMaxLength(8);

                
            }
        }
    }
}
