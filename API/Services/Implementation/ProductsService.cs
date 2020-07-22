using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Implementation
{
    public class ProductsService : IProductsService
    {
        IProductsRepository productsRepository;

        public ProductsService(IProductsRepository productsRepository){
            this.productsRepository = productsRepository;
        }

        //get all products in the system
        public IEnumerable<ProductDto> GetAllProducts(){
            return this.productsRepository.GetAllProducts();
        }
        
        //get product from the system given an ID
        public ProductDto GetProduct(int id){
            return this.productsRepository.GetProduct(id);
        }

        //get all orders for a specific product
        public IEnumerable<OrderDto> GetProductOrders(int id){
            return this.productsRepository.GetProductOrders(id);
        }
    }
}