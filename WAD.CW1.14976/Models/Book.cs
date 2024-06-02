using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WAD.CW1._14976.Models.BaseModel;

namespace WAD.CW1._14976.Models
{
    public class Book : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int PublicationYear { get; set; }

        [MaxLength(50)]
        public string Genre { get; set; }
    }
}
