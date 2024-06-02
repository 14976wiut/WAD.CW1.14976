using System.ComponentModel.DataAnnotations;

namespace WAD.CW1._14976.Models.BaseModel
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
