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
        private readonly DBContext dbContext;

        public ProductsRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //get all products in the system
        public IEnumerable<ProductDto> GetAllProducts(){
            return this.dbContext.Products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                ImageSource = p.ImageSource,
                price = p.price
            });
        }

        //get a specific order given an ID
        public ProductDto GetProduct(int id){
            var product = (from p in this.dbContext.Products
                        where p.Id == id
                        select new ProductDto()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            ImageSource = p.ImageSource,
                            price = p.price
                        }).FirstOrDefault();

            return product;
        }

        //get all orders for a specific product given an id
        public IEnumerable<OrderDto> GetProductOrders(int id){
            var orders = (from o in this.dbContext.Orders
                        where o.ProductId == id
                        select new OrderDto()
                        {
                            Id = o.Id,
                            ProductId = o.ProductId
                        });

            return orders;
        }

        //create order
        public bool CreateOrder(int id){
            var product = (from p in this.dbContext.Products
                        where p.Id == id
                        select new ProductDto()
                        {
                            Id = p.Id,
                            Name = p.Name,
                            ImageSource = p.ImageSource,
                            price = p.price
                        }).FirstOrDefault();
            
            if(product == null){
                return false;
            }
            else{
                this.dbContext.Add(new Order{ProductId = id});
                this.dbContext.SaveChanges();

                return true;
            }
        }
    }
}