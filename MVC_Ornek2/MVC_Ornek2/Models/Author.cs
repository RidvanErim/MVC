namespace MVC_Ornek2.Models
{
    public class Author : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        // relational property

        public List<Book> Books { get; set; }
    }
}
