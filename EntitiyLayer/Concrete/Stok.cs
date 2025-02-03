using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Stok
    {
        [Key]
        public int StokID { get; set; }

        public string MakinaKodu { get; set; }

        public string Bölümü { get; set; }

        public string ParçaAdı { get; set; }
        public int Miktar { get; set; }
        public DateTime son_güncelleme{get;set;}

    }
}
