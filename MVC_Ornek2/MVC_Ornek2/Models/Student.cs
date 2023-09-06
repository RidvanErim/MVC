using System.ComponentModel.DataAnnotations;

namespace MVC_Ornek2.Models
{
    public class Student : BaseEntity
    {
        //[Required]
        //[MaxLength(30)]
        // Yukarıdaki işlemlerle FirstName kolonu için, null olamama ve nvarchar(30) olma özellikleri ekledim. Bunları Fluent Api ile , model creating işleminde yapabilirsin
        public string FirstName { get; set; }

        //[MaxLength(20)]
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string PhoneNumber { get; set; }

        // relational property

        public List<Operation> Operations { get; set; }

    }
}
