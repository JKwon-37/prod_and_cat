#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class ProdCatAssociation
{
    [Key]
    public int ProdCatAssociationId {get;set;}

    public int ProductId {get;set;}
    public Product? ProdA {get;set;}

    public int CategoryId {get;set;}
    public Category? CatA {get;set;}
}