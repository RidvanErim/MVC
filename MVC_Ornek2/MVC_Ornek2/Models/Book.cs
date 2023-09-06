namespace MVC_Ornek2.Models
{
    public class Book : BaseEntity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int BookTypeId { get; set; }

        // relational Proporty

        public Author Author { get; set; }
        public BookType BookType { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
