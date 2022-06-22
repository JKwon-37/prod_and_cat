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
        List<Product> productsList = _context.Products.ToList();
        ViewBag.productsList = productsList;
        return View("AllProducts");
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
        Product? prod = _context.Products.FirstOrDefault(p => p.ProductId == productId);

        if (prod == null)
        {
            return RedirectToAction("ProductsPage");
        }
        return View(prod);
    }

    [HttpPost("products/{productId}/add")]
    public IActionResult AddCatToProd(int productId, int categoryId)
    {
        ProdCatAssociation? ass = new ProdCatAssociation()
        {
            ProductId = productId,
            CategoryId = categoryId
        };

        _context.Associations.Add(ass);
        _context.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}