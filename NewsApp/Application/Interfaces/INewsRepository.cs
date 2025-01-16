using NewsApp.Models;

namespace NewsApp.Application.Interfaces;

public interface INewsRepository
{
    public Task<ICollection<News?>> GetAllNews();
    public Task<News?> GetNewsDetailsById(int id);
    public bool CreateNews(News news);
    public bool UpdateNews(News news);
    public bool DeleteNews(News news);
}