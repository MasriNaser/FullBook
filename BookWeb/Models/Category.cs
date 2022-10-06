namespace BookWeb.Models;

public class Category
{
<<<<<<< HEAD
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
=======
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
>>>>>>> 5afdab9e48882f3ba95fe59b98e2758b408f090d

}
