namespace MVC_Ornek2.Models
{
    public class BookEditViewModel
    {
        public List<BookType> BookTypes { get; set; }
        public List<Author> Authors { get; set; }

        public Book Book { get; set; }

    }
}
