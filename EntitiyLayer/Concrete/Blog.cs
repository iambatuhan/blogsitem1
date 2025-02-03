using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }
    
        
        public string MakineKodu { get; set; }
        public string BlogImage { get; set; }
        public string BlogImage1 { get; set; }
        public string BlogImage2 { get; set; }
        public DateTime BlogDate{ get; set; }        
        public bool Calısma_Durum { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

       

    }
}

