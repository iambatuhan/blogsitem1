using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class AdminManager
    {
        Repository<Admin> repoadmin = new Repository<Admin>();
        public List<Admin> GetAll()
        {
            return repoadmin.List();
        }
        public List<Admin> BlogByID(int id)
        {
            return repoadmin.List().Where(x => x.AdminID == id).ToList();

        }
        public List<Admin> GetBlogByID(int id)
        {
            return repoadmin.List(x => x.AdminID == id);
        }
        public List<Admin> GetBlogByAuthorID(int id)
        {
            return repoadmin.List(x => x.AdminID == id);
        }
        public List<Admin> GetBlogByCategory(int id)
        {
            return repoadmin.List(x => x.AdminID == id);
        }
        public int BlogAddL(Admin p)
        {
            //if (p.BlogTitle == "" || p.BlogImage == "" || p.BlogTitle.Length <= 5 || p.BlogContent.Length <= 200)
            //{
            //    return -1;

            //}
            return repoadmin.Insert(p);
        }
        public int DeleteAdmin(int p)
        {
            Admin admin = repoadmin.Find(x => x.AdminID == p);
            return repoadmin.Delete(admin);
        }
        public Admin Update(int getid)
        {
            return repoadmin.Find(x => x.AdminID == getid);
        }
        public int UpdateBlog(Admin p)
        {
            Admin admin = repoadmin.Find(x => x.AdminID == p.AdminID);
            admin.UserName = p.UserName;
            admin.Password = p.Password;
            admin.AdminRole = p.AdminRole;
            return repoadmin.Update(admin);
        }
    }
}
