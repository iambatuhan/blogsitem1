using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
   public  class CategoryManager
    {
        Repository<Category> repocategory = new Repository<Category>();
        public List<Category> GetAll()
        {
            return repocategory.List();
        }
        public int BlogAddL(Category c)
        {
            //if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 5 || p.BlogContent.Length <= 200)
            //{
            //    return -1;

            //}
            return repocategory.Insert(c);
        }
        public int DeleteBlog(int p)
        {
            Category category = repocategory.Find(x => x.CategoryID == p);
            return repocategory.Delete(category);
        }
    }
}
