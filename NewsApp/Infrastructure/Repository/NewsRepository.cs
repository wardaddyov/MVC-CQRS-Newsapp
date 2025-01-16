using Microsoft.EntityFrameworkCore;
using NewsApp.Application.Interfaces;
using NewsApp.Infrastructure.Data;
using NewsApp.Models;

namespace NewsApp.Infrastructure.Repository;

public class NewsRepository(DataContext context) : INewsRepository
{
    public async Task<ICollection<News?>> GetAllNews()
    {
        return await context.News.Include(n=>n.Categories).ToListAsync();
    }

    public async Task<News?> GetNewsDetailsById(int id)
    {
        return await context.News.FindAsync(id);
    }

    public bool CreateNews(News news)
    {
        context.News.Add(news);
        return Save();
    }

    public bool UpdateNews(News news)
    {
        context.News.Update(news);
        return Save();
    }

    public bool DeleteNews(News news)
    {
        context.News.Remove(news);
        return Save();
    }
    
    private bool Save()
    {
        var saved = context.SaveChanges();
        return saved > 0 ? true : false;
    }
}