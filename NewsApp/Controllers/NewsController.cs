using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewsApp.Application.Commands.NewsCommands;
using NewsApp.Application.Queries.CategoryQueries;
using NewsApp.Application.Queries.NewsQueries;
using NewsApp.Models;

namespace NewsApp.Controllers;

public class NewsController(ISender sender) : Controller
{
    // GET: News
    public async Task<IActionResult> Index()
    {
        var news = await sender.Send(new GetAllNewsCommand());
        return View(news);
    }

    // GET: News/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var news = await sender.Send(new GetSingleNewsQuery(id));

        if (news == null) return NotFound();

        return View(news);
    }

    // GET: News/Create
    public async Task<IActionResult> Create()
    {
        await PopulateCategories();
        return View();
    }

    // POST: News/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(News news, int[] categories)
    {
        if (ModelState.IsValid)
        {
            await sender.Send(new CreateNewsCommand(news, categories));
            return RedirectToAction(nameof(Index));
        }

        await PopulateCategories(categories);
        return View(news);
    }

    // GET: News/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var news = await sender.Send(new GetSingleNewsQuery(id));
        if (news == null)
        {
            return NotFound();
        }

        await PopulateCategories(news.Categories.Select(c => c.CategoryId).ToArray());
        return View(news);
    }

    // POST: News/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, News news, int[] categories)
    {
        if (id != news.NewsId)
        {
            return NotFound();
        }

        var newsToUpdate = await sender.Send(new GetSingleNewsQuery(id));

        if (newsToUpdate == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<News>(
                newsToUpdate,
                "",
                n => n.Title, n => n.Content, n => n.PublishedDate, n => n.Author))
        {
            await sender.Send(new EditNewsCommand(newsToUpdate, categories));
            return RedirectToAction(nameof(Index));
        }

        await PopulateCategories(categories);
        return View(newsToUpdate);
    }

    // GET: News/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var news = await sender.Send(new GetSingleNewsQuery(id));
        if (news == null)
        {
            return NotFound();
        }

        return View(news);
    }

    // POST: News/Delete/5
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int newsId)
    {
        var news = await sender.Send(new GetSingleNewsQuery(newsId));

        if (news == null)
            return NotFound();

        await sender.Send(new DeleteNewsCommand(news));

        return RedirectToAction(nameof(Index));
    }

    // POST: News/DeleteSelected
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteSelected([FromBody] DeleteSelectedViewModel model)
    {
        if (model?.NewsIds == null || !model.NewsIds.Any())
        {
            return Json(new { success = false, message = "No news items selected." });
        }

        try
        {
            await sender.Send(new DeleteMultipleNewsCommand(model.NewsIds.ToArray()));
            return Json(new { success = true, deletedNewsIds = model.NewsIds });
        }

        catch (Exception ex)
        {
            // Log the exception (not shown here)
            return Json(new
                { success = false, message = "An error occurred while deleting news items. " + ex.Message });
        }
    }

    // ViewModel for DeleteSelected
    public class DeleteSelectedViewModel
    {
        public List<int> NewsIds { get; set; }
    }

    private async Task PopulateCategories(int[] selectedCategories = null)
    {
        var categories = await sender.Send(new GetCategoriesQuery());
        ViewBag.Categories = new MultiSelectList(categories, "CategoryId", "Name", selectedCategories);
    }
}