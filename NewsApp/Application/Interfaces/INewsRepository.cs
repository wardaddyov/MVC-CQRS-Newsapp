using NewsApp.Models;

namespace NewsApp.Application.Interfaces;

public interface INewsRepository
{
    public Task<ICollection<News?>> GetAllNewsAsync();
    public Task<ICollection<News?>> GetMultipleNewsByIdAsync(int[] ids);
    public Task<News?> GetNewsDetailsByIdAsync(int id);
    public bool CreateNews(News news);
    public bool UpdateNews(News news);
    public bool DeleteNews(News news);
    public bool DeleteMultipleNews(News?[] newsArray);
}