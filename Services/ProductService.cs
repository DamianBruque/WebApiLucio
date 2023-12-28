

using DataTransferObjects;
using Repositories;
using Services.Abstractions;

namespace Services;

public class ProductService : IProductService
{
    private readonly IProductRepository repository;
    public ProductService(IProductRepository productRepository)
    {
        repository = productRepository;
    }

    public Task<ProductDTO> Create(ProductDTO product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProductDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetAllBySellerId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDTO> Update(ProductDTO product)
    {
        throw new NotImplementedException();
    }
}
