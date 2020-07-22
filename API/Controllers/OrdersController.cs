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
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }

        // GET api/orders/
        // Returns all products in the system
        [HttpGet("")]
        public ActionResult<IEnumerable<OrderDto>> GetAllOrders()
        {
            return Ok(this.ordersService.GetAllOrders());
        }

        // GET api/orders/{orderId}
        // Returns profduct from the system given an id
        [HttpGet("{orderId}")]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            var order = this.ordersService.GetOrder(orderId);

            if(order == null){
                return NotFound();
            }
            else{
                return Ok(order);
            }
        }
    }
}