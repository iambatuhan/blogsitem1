using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class AuthorManager
    {
        Repository<Author> repoauthor = new Repository<Author>();
        public List<Author> GetAll()
        {
            return repoauthor.List();
        }
        public int AddAuthorBl(Author p)
        {
            if (p.AuthorName == "")
            {
                return -1;
            }
            return repoauthor.Insert(p);
        }
        public int DeleteBlog(int p)
        {
            Author blog = repoauthor.Find(x => x.AuthorID == p);
            return repoauthor.Delete(blog);
        }

        public Author FindAuthor(int getid)
        {
            return repoauthor.Find(x => x.AuthorID == getid);
        }
        public int EditAuthor(Author p)
        {
            Author author = repoauthor.Find(x => x.AuthorID == p.AuthorID);
            author.AuthorID = p.AuthorID;
            author.AuthorName = p.AuthorName;
         
            author.AuthorAbout= p.AuthorAbout;
            author.AuthorTitle = p.AuthorTitle;
          
            author.Mail = p.Mail;
            author.Password = p.Password;
          
            return repoauthor.Update(p);



        }
    

    }
    
}

