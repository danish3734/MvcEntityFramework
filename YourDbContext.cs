using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    public DbSet<Insuree> Insurees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Set your connection string here
        optionsBuilder.UseSqlServer("YourConnectionString");
    }
}
