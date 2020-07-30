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
    public class OrdersRepository: IOrdersRepository
    {
        private readonly IDBContext dbContext;

        public OrdersRepository(IDBContext dbContext){
            this.dbContext = dbContext;
        }

        //returns all orders in the DB
        public IEnumerable<OrderDto> GetAllOrders(){
            return this.dbContext.Orders.Select(o => new OrderDto
            {
                Id = o.Id,
                ProductId = o.ProductId
            });
        }

        //get order given an order ID
        public OrderDto GetOrder(int id){
            var orders = (from o in this.dbContext.Orders
                        where o.Id == id
                        select new OrderDto
                        {
                            Id = o.Id,
                            ProductId = o.ProductId
                        }).FirstOrDefault();

            return orders;
        }
    }
}