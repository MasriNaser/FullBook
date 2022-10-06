namespace BookWeb.Data;

public class ApplicationDbContext :DbContext
{
    //create a contracture
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> t) : base(t) => Console.WriteLine("this is the options" + t);
    public DbSet<Category> Categories { get; set; }
}
