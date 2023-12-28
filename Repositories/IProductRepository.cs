

using Models;

namespace Repositories;

public interface IProductRepository
{
    Task<ProductEntity> Create(ProductEntity product);
    Task<ProductEntity> Update(ProductEntity product);
    Task<ProductEntity> Delete(int id);
    Task<IEnumerable<ProductEntity>> GetAll();
    Task<ProductEntity> GetById(int id);
    Task<ProductEntity> GetBySellerId(int id);
}
