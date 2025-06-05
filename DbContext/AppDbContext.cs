using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProductInformation> Products { get; set; }
    public DbSet<UserInformation> UserInformation { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductInformationMap());
        modelBuilder.ApplyConfiguration(new UserInformationMap());
    }
}