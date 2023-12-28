

namespace Models;

public class SellerEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    public IEnumerable<ProductEntity> Products { get; set; }

}
