namespace BookWeb.Models;
public class Category
{
    //add annotation for validation
    [Key]
    //add properties
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [DisplayName("Display Order")]
    [Range(1,100,ErrorMessage ="Display Order must be 1 to 100 only.")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;

}
