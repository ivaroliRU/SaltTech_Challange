using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using SaltTechStore.Services.Implementation;
using SaltTechStore.Repositories.Implementation;
using SaltTechStore.Repositories.Data;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Models.EntityModels;
using System.Collections.Generic;
using System.Linq;

namespace SaltTechStore.Tests.Services
{
    public class OrderServiceTests
    {
        OrdersService ordersService;

        public OrderServiceTests(){
            //setup test data for orders service
            var data = new List<Order>{
                new Order{
                    Id = 1,
                    ProductId = 1
                },
                new Order{
                    Id = 2,
                    ProductId = 2
                }
            };

            var queryable = data.AsQueryable();

            var mockSet = new Mock<DbSet<Order>>();
            mockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            mockSet.Setup(d => d.Add(It.IsAny<Order>())).Callback<Order>((s) => data.Add(s));

            var mockContext = new Mock<IDBContext>();
            //mockContext.Setup(x => x.Products).Returns(dbSet.Object);

            mockContext.Setup(c => c.Orders).Returns(mockSet.Object);

            //setting up env for testing (switching out real db context with the fake one)
            OrdersRepository ordersRepository = new OrdersRepository(mockContext.Object);
            ordersService = new OrdersService(ordersRepository);
        }

        [Fact]
        public void OrderService_AreAllOrdersThere()
        {
            List<OrderDto> result = ordersService.GetAllOrders(0, 2).ToList();

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