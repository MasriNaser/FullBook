using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookWeb.Models
{
    public class Category
    {
        //add annotation for validation
        [Key]
        //add properties
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }

        [Required]
        [Range(1,100,ErrorMessage ="Display Order must be 1 to 100 only.")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
