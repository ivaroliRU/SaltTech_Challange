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
            var data = new List<Product>{
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
            }.AsQueryable();

            //setup mock database
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DBContext>();
            mockContext.Setup(c => c.Products).Returns(mockSet.Object);

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
        public void ProductService_IsTheCorrectOrdersThere()
        {
            List<OrderDto> result = productsService.GetProductOrders(1).ToList();
            Assert.True(result[0].ProductId == 1, "Return id should be 1");
        }
    }
}