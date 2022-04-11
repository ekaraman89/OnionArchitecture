using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Repositories;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            Random random = new Random();
            await _productWriteRepository.AddAsync(new Domain.Entities.Product
            {
                Name = $"Product {random.Next(1, 10)}",
                Price = random.Next(10, 100),
                Stock = random.Next(20, 30)
            });
            await _productWriteRepository.SaveAsync();
            var model = _productReadRepository.GetAll();
            return Ok(model);
        }

    }
}
