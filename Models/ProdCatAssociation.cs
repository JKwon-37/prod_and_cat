#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class ProdCatAssociation
{
    [Key]
    public int ProdCatAssociationId {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    public int ProductId {get;set;}
    public Product? Product {get;set;}

    public int CategoryId {get;set;}
    public Category? Category {get;set;}
}