#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace ProdAndCat.Models;
// the ProjectNameContext class representing a session with our MySQL database, allowing us to query for or save data
public class ProdAndCatContext : DbContext 
{ 
    public ProdAndCatContext(DbContextOptions options) : base(options) { }

    // the "TableName" table name will come from the DbSet property name
    // add DbSet<> properties below
    public DbSet<Product> Products { get; set; } 
    public DbSet<Category> Categories { get; set; } 
    public DbSet<ProdCatAssociation> Associations { get; set; } 
}