namespace MVC_Ornek2.Models
{
    // HANGI OGRENCI - HANGI KITAPI - NE ZAMAN ALDI - NE ZAMAN TESLIM ETTI
    public class Operation: BaseEntity  
    {
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // relational propety
        public Student Student { get; set; }
        public Book Book { get; set; }

    }
}
