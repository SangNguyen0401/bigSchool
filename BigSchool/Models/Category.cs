using System.ComponentModel.DataAnnotations;

namespace BigSchool.Models
{
    public class Category
    {
        public byte Id { get; set; }
        [Requied]
        [StringLength(255)]
        public string Name { get; set; }
    }
}