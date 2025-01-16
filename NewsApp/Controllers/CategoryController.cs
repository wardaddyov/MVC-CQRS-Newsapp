using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NewsApp.Application.Commands;
using NewsApp.Application.Queries;
using NewsApp.Models;

namespace NewsApp.Controllers;

public class CategoryController(ISender sender) : Controller
{
    // GET: Categories
    public async Task<IActionResult> Index()
    {
        var categories = await sender.Send(new GetCategoriesQuery());
        return View(categories);
    }

    // GET: Categories/Details/5
    public async Task<IActionResult> Details(GetCategoryCommand command)
    {
        var category = await sender.Send(command);

        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    // GET: Categories/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Categories/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Name,Description")] CreateCategoryCommand command)
    {
        if (ModelState.IsValid)
        {
            await sender.Send(command);
            return RedirectToAction(nameof(Index));
        }

        return View(command);
    }
    
    // GET: Categories/Edit/5
    public async Task<IActionResult> Edit(GetCategoryCommand command)
    {
        var category = await sender.Send(command);
        if (category == null)
            return NotFound();
        return View(category);
    }
    
    // POST: Categories/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CategoryId, Name, Description")] Category category)
    {
        if (id != category.CategoryId)
        {
            return NotFound();
        }

        /*// Log ModelState Validation State
        foreach (var key in ModelState.Keys)
        {
            var state = ModelState[key];
            foreach (var error in state.Errors)
            {
                Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
            }
        }*/
        
        if (ModelState.IsValid)
        {
            try
            {
                await sender.Send(new EditCategoryCommand(category));
            }
            catch (Exception e)
            {
                return Problem();
            }
            return RedirectToAction(nameof(Index));
        }
        
        return View(category);
    }
    
    // GET: Categories/Delete/5
    public async Task<IActionResult> Delete(GetCategoryCommand command)
    {
        var category = await sender.Send(command);
        
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }
    
    // POST: Categories/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int categoryId)
    {
        
        Console.WriteLine(categoryId);
        if (ModelState.IsValid)
            await sender.Send(new DeleteCategoryCommand(categoryId));
        return RedirectToAction(nameof(Index));
    }
}