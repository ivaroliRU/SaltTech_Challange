using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService _productsService)
        {
            this._productsService = _productsService;
        }

        // GET api/products/
        // Returns all products in the system
        [HttpGet("")]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(this._productsService.GetAllProducts());
        }

        // GET api/products/
        // Returns profduct from the system given an id
        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            return this._productsService.GetProduct(productId);
        }
    }
}