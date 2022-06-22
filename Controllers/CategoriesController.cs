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
    public IActionResult CategoryDetails(int catId)
    {
        Category? cat = _context.Categories
        .Include(p => p.Associations).ThenInclude(p => p.ProdA).FirstOrDefault(p => p.CategoryId == catId);
        List<Category> catList = _context.Categories
            .Include(c => c.Associations)
            .Where(c => !c.Associations.Any(a => a.CategoryId == catId)).ToList();
        ViewBag.catName = cat;
        ViewBag.catList = catList;


        if (cat == null)
        {
            return RedirectToAction("ProductsPage");
        }
            return View(cat);
    }
}