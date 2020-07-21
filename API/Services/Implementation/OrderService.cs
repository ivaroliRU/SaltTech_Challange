using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Implementation
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository){
            this.ordersRepository = ordersRepository;
        }

        //get all orders in the system
        public IEnumerable<OrderDto> GetAllOrders(){
            return this.ordersRepository.GetAllOrders();
        }
        
        //get order from the system given an ID
        public OrderDto GetOrder(int id){
            return this.ordersRepository.GetOrder(id);
        }
    }
}