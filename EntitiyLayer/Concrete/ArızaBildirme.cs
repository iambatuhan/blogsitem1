using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
   public  class ArızaBildirme
    {
        [Key]
        public int ArızaKayıtID { get; set; }
        public string GirenKisi { get; set; }
        public int CategoryID { get; set; }
        public string Acıklama { get; set; }
        public virtual Category Category { get; set; }
        public string MakineAdı { get; set; }
        public string MakineKodu { get; set; }
        public DateTime dateTime { get; set; }
        public string AciliyetDurumu { get; set; }
        public bool AtanmaDurum { get; set; }
        public string ÇalışmaDurum { get; set; }
        public string ArızaYeri { get; set; }
        public ICollection<Onarım> Onarıms { get; set; }
    }
}
