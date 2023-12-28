

namespace Models;

public class ClientEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public IEnumerable<PurchaseEntity> Buys { get; set; }

}
