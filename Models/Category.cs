#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Category
{
    [Key]
    public int CategoryId {get;set;}

    [Required(ErrorMessage = " must be required!")]
    public string Name {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    List<ProdCatAssociation> Association {get;set;} = new List<ProdCatAssociation>();
}