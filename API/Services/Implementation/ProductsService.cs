using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Services.Interfaces;
//using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Implementation
{
    public class ProductsService : IProductsService
    {
        public ProductsService(){
        }

        public List<ProductDto> GetAllProducts(){
            return new List<ProductDto>();
        }
    }
}