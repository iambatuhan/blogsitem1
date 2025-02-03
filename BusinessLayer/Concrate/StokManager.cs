using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Concrate
{
    public class StokManager 
    {
        Repository<Stok> repoadmin = new Repository<Stok>();
        public List<Stok> GetAll()
        {
            return repoadmin.List();
        }
        public List<Stok> BlogByID(int id)
        {
            return repoadmin.List().Where(x => x.StokID == id).ToList();
        }
        public List<Stok> GetBlogByID(int id)
        {
            return repoadmin.List(x => x.StokID == id);
        }
        public List<Stok> GetBlogByAuthorID(int id)
        {
            return repoadmin.List(x => x.StokID == id);
        }
        public List<Stok> GetBlogByCategory(int id)
        {
            return repoadmin.List(x => x.StokID == id);
        }
        public int BlogAddL(Stok p)
        {
            return repoadmin.Insert(p);
        }
        public int DeleteAdmin(int p)
        {
            Stok admin = repoadmin.Find(x => x.StokID == p);
            return repoadmin.Delete(admin);
        }
        public Stok Update(int getid)
        {
            return repoadmin.Find(x => x.StokID == getid);
        }
        public int UpdateBlog(Stok p)
        {
            Stok admin = repoadmin.Find(x => x.StokID == p.StokID);
            admin.MakinaKodu = p.MakinaKodu;
            admin.ParçaAdı = p.ParçaAdı;
            admin.Miktar = p.Miktar;
            admin.son_güncelleme = DateTime.Now;
            return repoadmin.Update(admin);
        }
    }
}