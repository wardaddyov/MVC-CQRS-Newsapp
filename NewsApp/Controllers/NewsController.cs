using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsApp.Application.Interfaces;

namespace NewsApp.Controllers;

public class NewsController(INewsRepository newsRepository, ICategoryRepository categoryRepository) : Controller
{
    // GET: News
    public async Task<IActionResult> Index()
    {
        var news = await newsRepository.GetAllNews();
        return View(news);
    }
    
    // GET: News/Create
    public async Task<IActionResult> Create()
    {
        await PopulateCategories();
        return View();
    }
    
    /*// POST: News/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(News news, int[] selectedCategories)
    {
        if (selectedCategories != null)
        {
            news.Categories = new List<Category>();
            foreach (var categoryId in selectedCategories)
            {
                var category = await _context.Categories.FindAsync(categoryId);
                if (category != null)
                {
                    news.Categories.Add(category);
                }
            }
        }

        if (ModelState.IsValid)
        {
            _context.Add(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        PopulateCategories(selectedCategories);
        return View(news);
    }*/

    
    private async Task PopulateCategories(int[] selectedCategories = null)
    {
        var categories = await categoryRepository.GetAllCategories();

        ViewBag.Categories = new MultiSelectList(categories, "CategoryId", "Name", selectedCategories);
    }
}