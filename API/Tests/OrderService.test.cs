using Xunit;
using SaltTechStore.Services.Implementation;
using SaltTechStore.Repositories.Implementation;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Repositories.Data;
using SaltTechStore.Models.DtoModels;
using System.Collections.Generic;
using System.Linq;

namespace SaltTechStore.Tests.Services
{
    public class OrderServiceTests
    {
        IOrdersService ordersService;

        public OrderServiceTests(){
            //setting up env for testing (switching out real db context with the fake one)
            IDBContext dbContext = new FakeDBContext();
            IOrdersRepository ordersRepository = new OrdersRepository(dbContext);
            ordersService = new OrdersService(ordersRepository);
        }

        [Fact]
        public void OrderService_AreAllOrdersThere()
        {
            List<OrderDto> result = ordersService.GetAllOrders().ToList();

            Assert.True(result.Count() == 2, "Return length should be 2");
        }

        [Fact]
        public void OrderService_IsTheCorrectOrderThere()
        {
            var result = ordersService.GetOrder(1);
            Assert.True(result.Id == 1, "Return id should be 1");
        }
    }
}