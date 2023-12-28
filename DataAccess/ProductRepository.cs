

using DataAccess.DBAccess;
using Models;
using Repositories;

namespace DataAccess;

public class ProductRepository : IProductRepository
{
    private readonly IConnection connection;
    public ProductRepository(IConnection connection)
    {
        this.connection = connection;
    }

    public Task<ProductEntity> Create(ProductEntity product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductEntity>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> GetBySellerId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> Update(ProductEntity product)
    {
        throw new NotImplementedException();
    }
}
