using NewsApp.Models;

namespace NewsApp.Application.Interfaces;

public interface ICategoryRepository
{
    public Task<ICollection<Category?>> GetAllCategories();
    public Task<Category?> GetCategoryByIdAsync(int id);
    public bool CreateCategory(Category category);
    public bool UpdateCategory(Category category);
    public bool DeleteCategory(Category category);
}