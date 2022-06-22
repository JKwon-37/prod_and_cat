using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdAndCat.Models;

public class CategoriesController : Controller
{
    private ProdAndCatContext _context;

    public CategoriesController(ProdAndCatContext context)
    {
        _context = context;
    }

    [HttpGet("categories")]
    public IActionResult CategoriesPage()
    {
        List<Category> allCategories = _context.Categories.ToList();
        ViewBag.allCategories = allCategories;
        return View("AllCategories");
    }

    [HttpPost("categories/create")]
    public IActionResult CreateCategory(Category category)
    {
        if(ModelState.IsValid)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return CategoriesPage();
    }
}