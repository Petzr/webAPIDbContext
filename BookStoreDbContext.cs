
using Microsoft.EntityFrameworkCore;

public class BookStoreDbContext : DbContext
{
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder b)
    {
        b.UseSqlite("Data Source=database.db");
    }
    public BookStoreDbContext(DbContextOptions o) : base(o)
    {}
}