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
    public class ProductServiceTests
    {
        IProductsService productsService;

        public ProductServiceTests(){
            //setting up env for testing (switching out real db context with the fake one)
            IDBContext dbContext = new FakeDBContext();
            IProductsRepository productRepository = new ProductsRepository(dbContext);
            productsService = new ProductsService(productRepository);
        }

        [Fact]
        public void ProductService_AreAllProductsThere()
        {
            List<ProductDto> result = productsService.GetAllProducts().ToList();

            Assert.True(result.Count() == 3, "Return length should be 3");
        }

        [Fact]
        public void ProductService_IsTheCorrectProductThere()
        {
            var result = productsService.GetProduct(1);
            Assert.True(result.Id == 1, "Return id should be 3");
        }
    }
}