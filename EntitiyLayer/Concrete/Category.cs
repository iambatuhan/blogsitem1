using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
     public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryAcıklama { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Author> Authors { get; set; }
       

    }
}
