using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EntitiyLayer.Concrete
{
    public class Onarım
    {
        [Key]
        public int OnarımID { get; set; }
        public string MakineKodu { get; set; }
        public int AuthorID { get; set; }
        public string KategoriAdı{get;set;}
        public string AcileyetDurumu { get; set; }
        public bool Başlama { get; set; }
        public string YapılacakIs { get; set; }
        public string Yapılmasıİs { get; set; }
        public string Yapılanİs { get; set; }
        public bool Durum { get; set; }
        public DateTime AtanmaSaati { get; set; }
        public virtual Author Author { get; set; }
        public int ArızaKayıtID { get; set; }
        public virtual ArızaBildirme ArızaBildirme { get; set; }
        public DateTime BaşlamaSaati { get; set; }
        public DateTime BitisSaati { get; set; }
        public  string KullanılanMalzemeler { get; set; }
        public bool AraVerme { get; set; }
        public DateTime AraVermeZamanı { get; set; }
        public string AraVermeNedeni { get; set; }
        public bool BitisDurum { get; set; }
        public double CalısmaZamnaı { get; set; }
        //public ICollection<GörevAta> görevAtas  { get; set; }
    }
}