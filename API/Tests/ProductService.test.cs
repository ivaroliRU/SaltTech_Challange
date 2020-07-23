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
    public class ProductServiceTests
    {
        ProductsService productsService;

        public ProductServiceTests(){
            //setup test data for the product service
            var product_data = new List<Product>{
                new Product{
                    Id = 1,
                    Name = "Test Product 1",
                    ImageSource = "adsf",
                    price = 1,
                    stock = 1
                },
                new Product{
                    Id = 2,
                    Name = "Test Product 2",
                    ImageSource = "adsf",
                    price = 1,
                    stock = 1
                },
                new Product{
                    Id = 3,
                    Name = "Test Product 3",
                    ImageSource = "adsf",
                    price = 1,
                    stock = 1
                }
            };
            var order_data = new List<Order>(){
                new Order{
                    Id = 0,
                    ProductId = 1
                }
            };


            var queryable = product_data.AsQueryable();
            var queryable_orders = order_data.AsQueryable();

            //setting up a fake db context for testing
            var productMockSet = new Mock<DbSet<Product>>();
            var orderMockSet = new Mock<DbSet<Order>>();
            
            //setting up behaviour for mock db
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(queryable.Provider);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(queryable.Expression);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            productMockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            orderMockSet.As<IQueryable<Order>>().Setup(m => m.Provider).Returns(queryable_orders.Provider);
            orderMockSet.As<IQueryable<Order>>().Setup(m => m.Expression).Returns(queryable_orders.Expression);
            orderMockSet.As<IQueryable<Order>>().Setup(m => m.ElementType).Returns(queryable_orders.ElementType);
            orderMockSet.As<IQueryable<Order>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_orders.GetEnumerator());

            productMockSet.Setup(d => d.Add(It.IsAny<Product>())).Callback<Product>((s) => product_data.Add(s));
            orderMockSet.Setup(d => d.Add(It.IsAny<Order>())).Callback<Order>((s) => order_data.Add(s));

            var mockContext = new Mock<IDBContext>();

            mockContext.Setup(c => c.Products).Returns(productMockSet.Object);
            mockContext.Setup(c => c.Orders).Returns(orderMockSet.Object);

            //setting up env for testing (switching out real db context with the fake one)
            ProductsRepository productRepository = new ProductsRepository(mockContext.Object);
            productsService = new ProductsService(productRepository);
        }

        [Fact]
        public void ProductService_AreAllProductsThere()
        {
            List<ProductDto> result = productsService.GetAllProducts(0, 10, "").ToList();

            Assert.True(result.Count() == 3, "Return length should be 3");
        }

        [Fact]
        public void ProductService_IsTheCorrectProductThere()
        {
            var result = productsService.GetProduct(1);
            Assert.True(result.Id == 1, "Return id should be 1");
        }

        [Fact]
        public void ProductService_CanAddOrders()
        {
            productsService.CreateOrder(1);
            var result = productsService.GetProductOrders(1);

            Assert.True(result.ToList()[0].ProductId == 1, "Return id should be 1");
        }
    }
}