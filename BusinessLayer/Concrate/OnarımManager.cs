using DataAccessLayer.Concrate;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusinessLayer.Concrate
{
    public class OnarımManager
    {
        Repository<Onarım> reponarım = new Repository<Onarım>();
        public List<Onarım> GetAll()
        {
            return reponarım.List();
        }
        public List<Onarım> BlogByID(int id)
        {
            return reponarım.List().Where(x => x.OnarımID == id).ToList();
        }
        public List<Onarım> GetBlogByID(int id)
        {
            return reponarım.List(x => x.OnarımID == id);
        }
        public List<Onarım> GetBlogByAuthorID(int id)
        {
            return reponarım.List(x => x.OnarımID == id);
        }
        public List<Onarım> GetBlogByCategory(int id)
        {
            return reponarım.List(x => x.OnarımID == id);
        }
        public int BlogAddL(Onarım p)
        {
            p.Durum = true;
            return reponarım.Insert(p);
        }
        public int DeleteAdmin(int p)
        {
            Onarım admin = reponarım.Find(x => x.OnarımID == p);
            return reponarım.Delete(admin);
        }
        public Onarım Update(int getid)
        {
            return reponarım.Find(x => x.OnarımID == getid);
        }
        public int UpdateBlog(Onarım p)
        {
            Onarım admin = reponarım.Find(x => x.OnarımID == p.OnarımID);
            admin.AuthorID = p.AuthorID;
         
            admin.MakineKodu = p.MakineKodu;
            admin.YapılacakIs = p.YapılacakIs;
            admin.Yapılanİs = p.Yapılanİs;
            admin.Durum = p.Durum;
            admin.AcileyetDurumu = p.AcileyetDurumu;
            admin.ArızaKayıtID = p.ArızaKayıtID;
            admin.Başlama = p.Başlama;
            admin.Yapılmasıİs = p.Yapılmasıİs;
            admin.BitisDurum = p.BitisDurum;
            admin.BitisSaati = p.BitisSaati;
            return reponarım.Update(admin);
        }
        public Onarım Update1(int getid)
        {
            return reponarım.Find(x => x.OnarımID == getid);
        }
        public int UpdateBlog1(Onarım p)
        {
            Onarım admin = reponarım.Find(x => x.OnarımID == p.OnarımID);
            admin.Yapılmasıİs = p.Yapılmasıİs;
            admin.Başlama = true;
            admin.BaşlamaSaati = DateTime.Now;
            admin.BitisSaati = DateTime.Now;
            return reponarım.Update(admin);
        }
        public Onarım Update2(int getid)
        {
            return reponarım.Find(x => x.OnarımID == getid);
        }
        public int UpdateBlog2(Onarım p)
        {
            Onarım admin = reponarım.Find(x => x.OnarımID == p.OnarımID);
            // Yapılan işlemi güncelle
            admin.Yapılanİs = p.Yapılanİs;
            // Bitiş durumunu tamamlanmış olarak işaretle
            admin.BitisDurum = true;
            // Kullanılan malzemeleri güncelle
            admin.KullanılanMalzemeler = p.KullanılanMalzemeler;
            // BitisSaati güncelleniyor
            admin.BitisSaati = DateTime.Now;
            // BaşlamaSaati'nin null olup olmadığını kontrol et
            if (admin.BaşlamaSaati != null)
            {
                // Çalışma zamanını hesapla
                TimeSpan calismaZamani = admin.BitisSaati - admin.BaşlamaSaati;
                // Çalışma zamanını dakika cinsinden kaydet
                admin.CalısmaZamnaı = calismaZamani.TotalHours;
            }
            else
            {
                // Eğer BaşlamaSaati null ise çalışma zamanını 0 olarak ayarla
                admin.CalısmaZamnaı = 0;
            }
            return reponarım.Update(admin);
        }
        public Onarım Update3(int getid)
        {
            return reponarım.Find(x => x.OnarımID == getid);
        }
        public int UpdateBlog3(Onarım p)
        {
            Onarım admin = reponarım.Find(x => x.OnarımID == p.OnarımID);
            admin.AraVermeNedeni = p.AraVermeNedeni;
            admin.AraVerme = true;
            admin.AraVermeZamanı = DateTime.Now;
            return reponarım.Update(admin);
        }
    }
}