namespace MVC_Ornek2.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFullName
        {
            get
            {
                return AuthorFirstName + " " + AuthorLastName;
            }
        }
        public string BookTypeName { get; set; }

    }
}
