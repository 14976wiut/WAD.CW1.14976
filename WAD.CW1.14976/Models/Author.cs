using System.ComponentModel.DataAnnotations;
using WAD.CW1._14976.Models.BaseModel;

namespace WAD.CW1._14976.Models
{
    public class Author : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        [MaxLength(50)]
        public string Nationality { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
