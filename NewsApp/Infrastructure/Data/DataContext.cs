using Microsoft.EntityFrameworkCore;
using NewsApp.Models;

namespace NewsApp.Infrastructure.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<News> News { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure category name unique constraint
        modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();
        
        // Configure many-to-many relationship
        modelBuilder.Entity<News>()
            .HasMany(n => n.Categories)
            .WithMany(c => c.NewsItems)
            .UsingEntity<Dictionary<string, object>>(
                "NewsCategory", // Name of the join table
                j => j
                    .HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId")
                    .HasConstraintName("FK_NewsCategory_Categories_CategoryId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<News>()
                    .WithMany()
                    .HasForeignKey("NewsId")
                    .HasConstraintName("FK_NewsCategory_News_NewsId")
                    .OnDelete(DeleteBehavior.Cascade),
                j =>
                {
                    j.HasKey("NewsId", "CategoryId");
                    j.ToTable("NewsCategory");
                });
    }
}