using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Concrate
{
    public class BlogManager
    {
        Repository<Blog> repoblog = new Repository<Blog>();
        public List<Blog> GetAll()
        {
            return repoblog.List();
        }
        public List<Blog> BlogByID(int id)
        {
            return repoblog.List().Where(x => x.BlogID == id).ToList();
        }
        public List<Blog> GetBlogByID(int id)
        {
            return repoblog.List(x => x.BlogID == id);
        }
        public List<Blog> GetBlogByCategory(int id)
        {
            return repoblog.List(x => x.CategoryID == id);
        }
        public int BlogAddL(Blog p)
        {
            return repoblog.Insert(p);
        }
        public int DeleteBlog(int p)
        {
            Blog blog = repoblog.Find(x => x.BlogID == p);
            return repoblog.Delete(blog);
        }
        public Blog Update(int getid)
        {
            return repoblog.Find(x => x.BlogID == getid);
        }
        public int UpdateBlog(Blog p)
        {
            Blog blog = repoblog.Find(x => x.BlogID == p.BlogID);
         
            blog.BlogImage = p.BlogImage;
            blog.BlogDate = p.BlogDate;
            blog.CategoryID = p.CategoryID;
            blog.MakineKodu = p.MakineKodu;
            blog.Calısma_Durum = p.Calısma_Durum;
            return repoblog.Update(blog);
        }
    }
}