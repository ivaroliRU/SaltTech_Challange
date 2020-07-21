using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Repositories.Data;

namespace SaltTechStore.Repositories.Implementation
{
    public class ProductsRepository: IProductsRepository
    {
        private readonly IDBContext dbContext;

        public ProductsRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<ProductDto> GetAllProducts(){
            return this.dbContext.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name
            });
        }

        public ProductDto GetProduct(int id){
            var product = (from p in this.dbContext.Products
                        where p.Id == id
                        select new ProductDto()
                        {
                            Id = p.Id,
                            Name = p.Name
                        }).FirstOrDefault();

            return product;
        }
    }
}