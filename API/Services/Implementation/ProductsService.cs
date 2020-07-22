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
        public IEnumerable<ProductDto> GetAllProducts(int page, int pageSize, string name){
            List<ProductDto> products = this.productsRepository.GetAllProducts(name).ToList();
            List<ProductDto> result = new List<ProductDto>();

            for(int i = page*pageSize; i < products.Count() && i < (page+1)*pageSize; i++){
                result.Add(products.ElementAt(i));
            }

            return result;
        }
        
        //get product from the system given an ID
        public ProductDto GetProduct(int id){
            return this.productsRepository.GetProduct(id);
        }

        //get all orders for a specific product
        public IEnumerable<OrderDto> GetProductOrders(int id){
            return this.productsRepository.GetProductOrders(id);
        }

        //create order for a specific product
        public bool CreateOrder(int id){
            return this.productsRepository.CreateOrder(id);
        }
    }
}