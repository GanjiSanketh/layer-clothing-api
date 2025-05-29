using System.ComponentModel.DataAnnotations;

public class ProductInformation
{
    [Key]
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal Amount { get; set; }
    public decimal Discount { get; set; }
    public bool IsInStock { get; set; }
    public int StatusId { get; set; }

    public ProductInformation()
    {
        ProductName = string.Empty;
    }
}