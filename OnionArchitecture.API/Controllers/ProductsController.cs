using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Abstractions;

namespace OnionArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            this._productService = productService;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _productService.GetProducts();
            return Ok(model);
        }

    }
}
