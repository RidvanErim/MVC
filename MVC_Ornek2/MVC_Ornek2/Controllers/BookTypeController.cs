using Microsoft.AspNetCore.Mvc;
using MVC_Ornek2.Context;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Controllers
{
    public class BookTypeController : Controller
    {
        private readonly LibraryDbContext _db;
        // readonly -> müdahalenin yalnızca ctor'da yapılabileceği anlamına gelir.
        public BookTypeController(LibraryDbContext db)
        {
            _db = db;
        }
        // Dependency Injection ^^

        // _db -> BookTypeController'a her istek atıldığından kullanılacak olan bir veritabanı kopyası.

        // Bir class'a ait olan metotların/propertylerin başka bir class içerisinde kullanılabilmesi için o classtan bir nesne üretilmesi (new) gerekir.

        // Dependency injection ile bu newleme işlemini otomatiğe bağlıyorum.

        public IActionResult Index()
        {

            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false).ToList();
            // veritabanın kitapları çekme kodu.

            _db.BookTypes.ToList();

            return View("List" , bookTypes);
            
        }

        [HttpGet]
        // URL'den istek attığın action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        // Form'dan tetiklediğin action
        public IActionResult Create(BookType formData)
        {

            _db.BookTypes.Add(formData); // Veritabanı örneğine veriyi ekledim.

            _db.SaveChanges(); // Asıl veritabanına kayıt ettim.

            return RedirectToAction("List");
            // beni Index action'ına yönlendir.
            // Index action'ı içerisindeki kodlar çalışsın ve hangi view'e gönderiyorsa, orayı görelim.
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bookType = _db.BookTypes.Find(id);

            return View(bookType);
        }

        [HttpPost]
        public IActionResult Edit(BookType formData)
        {
            formData.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(formData);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {

            // HARD DELETE
            //var bookType = _db.BookTypes.Find(id);
            //_db.BookTypes.Remove(bookType);
            //_db.SaveChanges();


            // SOFT DELETE

            var bookType = _db.BookTypes.Find(id);

            bookType.IsDeleted = true;
            bookType.ModifiedDate = DateTime.Now;

            _db.BookTypes.Update(bookType);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
