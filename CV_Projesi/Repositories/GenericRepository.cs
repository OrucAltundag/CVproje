using CV_Proje.Models.Entity; // Proje içinde yer alan entity modellerine erişim sağlar.
using System;   // Genel amaçlı .NET sınıflarına erişim sağlar.
using System.Collections.Generic; // Koleksiyon tiplerine (List, Dictionary vb.) erişim sağlar.
using System.Linq;  // LINQ (Language Integrated Query) desteği sağlar.
using System.Linq.Expressions; // LINQ içinde lambda ifadelerinin kullanımını destekler.
using System.Web;  // ASP.NET web uygulamalarında kullanılan sınıflara erişim sağlar.


namespace CV_Proje.Repositories // Kodları organize etmek için bir namespace tanımlanıyor.
{
    // Generic bir repository sınıfı tanımlanıyor. T, üzerinde çalışılacak sınıfın türünü temsil eder.
    public class GenericRepository<T> where T : class, new() // T sadece bir sınıf olmalı ve parametresiz bir constructor'a sahip olmalıdır.
    {
        // Veritabanı bağlantısı için entity framework'ün oluşturduğu db context sınıfı kullanılıyor.
        dbCVEntities db = new dbCVEntities();

        // T türündeki tüm kayıtları listelemek için bir metot.
        public List<T> List()
        {
            // Veritabanında T türüne ait tüm kayıtları listeye çevirir.
            return db.Set<T>().ToList();
        }
        // Yeni bir kayıt eklemek için kullanılan metot.
        public void TAdd(T p)
        {
            db.Set<T>().Add(p);            // Verilen kaydı veritabanına ekler.
            db.SaveChanges();         // Değişiklikleri veritabanına kaydeder.
        }

        public void Tdelete(T p)   // Bir kaydı silmek için kullanılan metot.
        {
            db.Set<T>().Remove(p); // Verilen kaydı veritabanından kaldırır.
            db.SaveChanges();
        }
        public T TGet(int id)    // Belirtilen bir ID'ye göre kayıt getiren metot.
        {
            return db.Set<T>().Find(id);   // Verilen ID'ye sahip kaydı döndürür.

        }

        public void TUpdate(T p)   // Bir kaydı güncellemek için kullanılan metot.
        {
            // Burada yalnızca SaveChanges çağrılıyor. Güncelleme işlemi öncesinde
            // var olan kaydın değiştirilmiş olması gerekir.
            db.SaveChanges(); // Değişiklikleri veritabanına kaydeder.
        }
        public T find(Expression<Func<T, bool>> where)   // Lambda ifadesiyle belirli bir koşula uyan ilk kaydı bulan metot.
        {
            return db.Set<T>().FirstOrDefault(where);   // Veritabanında belirtilen koşulu sağlayan ilk kaydı döndürür.
        }

    }
}