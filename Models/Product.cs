namespace CQRSMediatr.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public decimal BuyingPrice { get; set; }
    public string ConfidentialData { get; set; } = string.Empty;
}