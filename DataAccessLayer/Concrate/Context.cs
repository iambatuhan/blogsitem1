using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context : DbContext
    {

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<ArızaBildirme> ArızaBildirmes { get; set; }

        public DbSet<Stok> Stoks { get; set; }
        public DbSet<Onarım> Onarıms { get; set; }

        //public DbSet<GörevAta> GörevAtas { get; set; }



    }
}
