using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Abstractions
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}
