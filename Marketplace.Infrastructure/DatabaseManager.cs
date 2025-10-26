using Microsoft.EntityFrameworkCore;
using Marketplace.Domain.Entities;

namespace Marketplace.Infrustructure.Presentation;
public class DatabaseManager :DbContext
{
    static readonly string connectionString = "Server=localhost; User ID=root; Password=root; Database=test";

    public DbSet<User> Users { get; set; }
    public DbSet<Item> Items { get; set; }

    public DatabaseManager(DbContextOptions<DatabaseManager> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>(eb =>
        {
            eb.HasKey(u => u.UserId);
            eb.Property(u => u.Username).IsRequired().HasMaxLength(100);
            eb.Property(u => u.Email).IsRequired().HasMaxLength(200);
        });
        modelBuilder.Entity<Item>(eb =>
        {
            eb.HasKey(i => i.Id);
            eb.Property(i => i.Title).IsRequired().HasMaxLength(200);
            eb.Property(i=>i.Price).HasColumnType("decimal(18,2)");
        });

        modelBuilder.Entity<User>()
            .HasMany(u => u.Items)
            .WithMany(i => i.Users)
            .UsingEntity<Dictionary<string, object>>(
                "UserItems",
                u => u.HasOne<Item>().WithMany().HasForeignKey("ItemId").OnDelete(DeleteBehavior.Cascade),
                i => i.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("UserId", "ItemId");
                    j.ToTable("UserItems");
                });
    }
}
