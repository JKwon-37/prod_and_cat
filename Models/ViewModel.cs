#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdAndCat.Models;

[NotMapped]
public class IndexViewModel
{
    public Product VProd {get;set;}
    public Category VCat {get;set;}
}