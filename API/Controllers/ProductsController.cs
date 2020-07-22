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
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        // GET api/products/
        // Returns all products in the system
        [HttpGet("")]
        public ActionResult<IEnumerable<ProductDto>> GetAllProducts()
        {
            return Ok(this.productsService.GetAllProducts());
        }

        // GET api/products/{productId}
        // Returns profduct from the system given an id
        [HttpGet("{productId}")]
        public ActionResult<ProductDto> GetProduct(int productId)
        {
            var product =  this.productsService.GetProduct(productId);

            if(product == null){
                return NotFound();
            }
            else{
                return Ok(product);
            }
        }

        // GET api/products/{productId}/orders
        // Returns returns orders for a product given a product ID
        [HttpGet("{productId}/orders")]
        public ActionResult<OrderDto> GetProductOrders(int productId)
        {
            var orders = productsService.GetProductOrders(productId);

            if(orders == null){
                return NotFound();
            }
            else{
                return Ok(orders);
            }
        }
    }
}