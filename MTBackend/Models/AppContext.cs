using Microsoft.EntityFrameworkCore;

namespace MTBackend.Models
{
    public class AppDbContent : DbContext{
    public DbSet<User> Users { get; set; }
    public AppDbContent(DbContextOptions<AppDbContent> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseSerialColumns();
    }
}
}

