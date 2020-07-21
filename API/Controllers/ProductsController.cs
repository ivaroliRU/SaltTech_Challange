using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SaltTechStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController()
        {
        }

        // GET api/products/
        // Returns all products in the system
        [HttpGet("")]
        public ActionResult GetAllProducts()
        {
            return NoContent();
        }
    }
}