#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int ProductId {get;set;}

    [Required(ErrorMessage = " must be required!")]
    public string Name {get;set;}

    [Required(ErrorMessage = " must be required!")]
    public string Description {get;set;}

    [Required(ErrorMessage = " must be required!")]
    public decimal? Price {get;set;}

    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;
}