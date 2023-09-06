namespace MVC_Ornek2.Models
{
    public class BookType : BaseEntity
    {
        public string Name { get; set; }

        // relational property
        public List<Book> Books { get; set; }
    }
}
