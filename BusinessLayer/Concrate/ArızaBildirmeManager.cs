using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class ArızaBildirmeManager
    {
        Repository<ArızaBildirme> repoarızabildirme = new Repository<ArızaBildirme>();
        //Repository<GörevAta> repogorevata = new Repository<GörevAta>();
        public List<ArızaBildirme> GetAll()
        {
            return repoarızabildirme.List();
        }
        public List<ArızaBildirme> BlogByID(int id)
        {
            return repoarızabildirme.List().Where(x => x.ArızaKayıtID == id).ToList();

        }
        public List<ArızaBildirme> GetBlogByID(int id)
        {
            
            return repoarızabildirme.List(x => x.ArızaKayıtID == id);
        }
        public List<ArızaBildirme> GetBlogByAuthorID(int id)
        {
            return repoarızabildirme.List(x => x.ArızaKayıtID == id);
        }
        public List<ArızaBildirme> GetBlogByCategory(int id)
        {
            return repoarızabildirme.List(x => x.ArızaKayıtID == id);
        }
        public int BlogAddL(ArızaBildirme p)
        {
            //if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 5 || p.BlogContent.Length <= 200)
            //{
            //    return -1;

            //}
            return repoarızabildirme.Insert(p);
        }
        public int DeleteAdmin(int p)
        {
            ArızaBildirme admin = repoarızabildirme .Find(x => x.ArızaKayıtID == p);
            return repoarızabildirme.Delete(admin);
        }
        public ArızaBildirme Update(int getid)
        {
            return repoarızabildirme.Find(x => x.ArızaKayıtID == getid);
        }
        public int UpdateBlog(ArızaBildirme p)
        {
            ArızaBildirme blog = repoarızabildirme.Find(x => x.ArızaKayıtID == p.ArızaKayıtID);
            blog.Acıklama = p.Acıklama;
            blog.MakineAdı = p.MakineKodu;
            blog.MakineKodu = p.MakineKodu;
            blog.CategoryID = p.CategoryID;
            blog.AciliyetDurumu = p.AciliyetDurumu;
            return repoarızabildirme.Update(blog);
        }
    }
}
