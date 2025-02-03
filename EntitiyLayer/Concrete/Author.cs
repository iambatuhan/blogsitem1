using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Concrete
{
    public class Author
    {
        [Key]
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public string AuthorAbout { get; set; }
        public string AuthorTitle { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public ICollection<Onarım> Onarıms { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        //public ICollection<GörevAta> GörevAtas { get; set; }

    }
}
