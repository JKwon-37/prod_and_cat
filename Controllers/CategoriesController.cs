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
        List<Category> allCats = _context.Categories.ToList();
        return View("AllCategories", allCats);
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

    [HttpGet("categories/{categoryId}")]
    public IActionResult CategoryDetails(int categoryId)
    {
        Category? cat = _context.Categories
        .Include(c => c.Associations).ThenInclude(p => p.ProdA).FirstOrDefault(c => c.CategoryId == categoryId);
        List<Product> prodList = _context.Products
            .Include(p => p.Associations)
            .Where(p => !p.Associations.Any(a => a.CategoryId == categoryId)).ToList();
        ViewBag.catName = cat;
        ViewBag.prodList = prodList;


        if (cat == null)
        {
            return RedirectToAction("CategoriesPage");
        }
            return View(cat);
    }
}