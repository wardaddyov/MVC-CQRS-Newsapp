using Microsoft.EntityFrameworkCore;
using NewsApp.Application.Interfaces;
using NewsApp.Infrastructure.Data;
using NewsApp.Models;

namespace NewsApp.Infrastructure.Repository;

public class CategoryRepository(DataContext context) : ICategoryRepository
{
    public async Task<ICollection<Category?>> GetAllCategories()
    {
        return await context.Categories.Include(c=>c.NewsItems).ToListAsync();
    }

    public async Task<Category?> GetCategoryByIdAsync(int id)
    {
        return await context.Categories
            .Include(c => c.NewsItems) // Include the NewsItems navigation property
            .FirstOrDefaultAsync(c => c.CategoryId == id); // Use FirstOrDefaultAsync for more control
    }

    public bool CreateCategory(Category category)
    {
        context.Categories.Add(category);
        return Save();
    }

    public bool UpdateCategory(Category category)
    {
        context.Categories.Update(category);
        return Save();
    }

    public bool DeleteCategory(Category category)
    {
        category?.NewsItems?.Clear();
        context.Categories.Remove(category);
        return Save();
    }

    public Task<bool> CategoryExistsWithTheNameAsync(string name)
    {
        return context.Categories.AnyAsync(c => c.Name == name);
    }

    private bool Save()
    {
        var saved = context.SaveChanges();
        return saved > 0 ? true : false;
    }
}