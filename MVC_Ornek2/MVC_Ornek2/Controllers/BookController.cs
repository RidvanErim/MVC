using Microsoft.AspNetCore.Mvc;
using MVC_Ornek2.Context;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _db;

        public BookController(LibraryDbContext db)
        {
            _db = db;
        }

        

        public IActionResult Index()
        {
            var viewModel = _db.Books.Where(x => x.IsDeleted == false).Select(x => new BookViewModel()
            {
                Id = x.Id,
                BookName = x.Name,
                PageCount = x.PageCount,
                AuthorFirstName = x.Author.FirstName,
                AuthorLastName = x.Author.LastName,
                BookTypeName = x.BookType.Name

            }).ToList();

            return View("List" , viewModel);

            // Books tablosu içerisindeki her bir veriye x diyorum. Her bir veri için yeni bir tane BookViewModel nesnesi oluşturup, verileri onun içerisine aktarıyorum.

            // ToList() -> diyene kadar ki kısım bir sorgu -> Query

            // Tolist() -> Asıl işin yapıldığı, verilerin sql tarafından çekildiği ve ram'de liste olarak tutulduğu aşama.

        }

        [HttpGet]
        public IActionResult Create()
        {
            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false).ToList();

            var authors = _db.Authors.Where(x => x.IsDeleted == false).OrderBy(x => x.FirstName).ToList();

            var viewModel = new BookCreateViewModel()
            {
                Authors = authors,
                BookTypes = bookTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel formData)
        {
            var book = formData.Book;

            _db.Books.Add(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            var book = _db.Books.Find(id);

            var authors = _db.Authors.Where(x => x.IsDeleted == false).OrderBy(x => x.FirstName).ToList();

            var bookTypes = _db.BookTypes.Where(x => x.IsDeleted == false).ToList();

            var viewModel = new BookEditViewModel()
            {
                Book = book,
                Authors = authors,
                BookTypes = bookTypes
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData)
        {
            var book = formData.Book;

            book.ModifiedDate = DateTime.Now;

            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("index");

        }


        public IActionResult Delete(int id)
        {
            var book = _db.Books.Find(id);

            book.ModifiedDate = DateTime.Now;
            book.IsDeleted = true;

            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
