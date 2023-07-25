using Microsoft.AspNetCore.Mvc;
using RealEstate.Application.Features.Product.Queries;
using RealEstate.Application.Interfaces.Application.Features.Product;

namespace RealEstate.WebAPI.Controllers.Product
{
    [Route("api/[controller]")]
    public class ProductController :Persistence.ControllerBase.ControllerBase
    {
        private readonly IProductManager _productManager;
        public ProductController(IProductManager productManager)
        {
            _productManager = productManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQuery getAllUsersQuery)
        {
            return Ok(await _productManager.GetList(getAllUsersQuery));
        } 
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] GetProductByIdQuery getUserByIdQuery)
        {
            return Ok(await _productManager.GetById(getUserByIdQuery));
        }
    }
}
