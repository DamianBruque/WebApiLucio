

namespace Models;

public class SoldItemEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public ProductEntity Product { get; set; }
    public int SaleId { get; set; }
    public PurchaseEntity Sale { get; set; }
    public int Quantity { get; set; }
    public Decimal Subtotal { get; set; }
}
