using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Models.InputModels;
using Microsoft.AspNetCore.Cors;

namespace SaltTechStore.Controllers
{
    //[EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService){
            this.ordersService = ordersService;
        }

        // GET api/orders/
        // Returns all products in the system
        [HttpGet("")]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrders([FromQuery(Name = "page")] int page = 0, 
                                                                [FromQuery(Name = "page_size")] int pageSize = 10){
            return Ok(this.ordersService.GetAllOrders(page, pageSize));
        }

        // GET api/orders/{orderId}
        // Returns profduct from the system given an id
        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetOrder(int orderId){
            var order = this.ordersService.GetOrder(orderId);

            if(order == null){
                return NotFound();
            }
            else{
                return Ok(order);
            }
        }

        //create multible orders using the body
        [HttpPost]
        public ActionResult<OrderDto> CreateOrders(List<OrderInput> input){
            var response = this.ordersService.CreateOrders(input);

            if(!response){
                return NotFound();
            }
            else{
                return NoContent();
            }
        }
    }
}