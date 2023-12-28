

namespace Models;

public class PurchaseEntity
{
    public int Id { get; set; }
    public int SellerId { get; set; }
    public SellerEntity Seller { get; set; }
    public int BuyerId { get; set; }
    public ClientEntity Buyer { get; set; }
    public IEnumerable<SoldItemEntity> Items { get; set; }
    public Decimal Total { get; set; }
    public DateTime Date { get; set; }
}
