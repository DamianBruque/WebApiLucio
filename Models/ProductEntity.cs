

namespace Models;

public class ProductEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public Decimal Price { get; set; }
    public int Stock { get; set; }
    public IEnumerable<SoldItemEntity> ItemEntities { get; set; }
    public int CreatorId { get; set; }
    public SellerEntity Creator { get; set; }

}
