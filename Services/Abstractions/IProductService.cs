

using DataTransferObjects;

namespace Services.Abstractions;

public interface IProductService
{
    Task<ProductDTO> Create(ProductDTO product);
    Task<ProductDTO> Delete(int id);
    Task<ProductDTO> Update(ProductDTO product);
    Task<ProductDTO> GetById(int id);
    Task<IEnumerable<ProductDTO>> GetAll();
    Task<ProductDTO> GetAllBySellerId(int id);
}
