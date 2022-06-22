using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdAndCat.Models;

public class ProductsController : Controller
{
    private ProdAndCatContext _context;

    public ProductsController(ProdAndCatContext context)
    {
        _context = context;
    }

    [HttpGet("products")]
    public IActionResult ProductsPage()
    {
        List<Product> allPosts = _context.Products.ToList();
        return View("AllProducts", allPosts);
    }

    [HttpPost("products/create")]
    public IActionResult CreateProduct(Product product)
    {
        if(ModelState.IsValid)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        return ProductsPage();
    }

    [HttpGet("products/{productId}")]
    public IActionResult ProductDetails(int productId)
    {
        Product? prod = _context.Products
        .Include(p => p.Associations).ThenInclude(p => p.CatA).FirstOrDefault(p => p.ProductId == productId);
        List<Category> catList = _context.Categories
            .Include(c => c.Associations)
            .Where(c => !c.Associations.Any(a => a.ProductId == productId)).ToList();
        ViewBag.prodName = prod;
        ViewBag.catList = catList;


        if (prod == null)
        {
            return RedirectToAction("ProductsPage");
        }
            return View(prod);
    }

    [HttpPost("products/{productId}/add")]
    public IActionResult AddCat(int productId, ProdCatAssociation newAss)
    {
            newAss.ProductId = productId;
            _context.Associations.Add(newAss);
            _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}