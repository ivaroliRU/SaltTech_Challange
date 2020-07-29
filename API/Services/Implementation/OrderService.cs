using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Services.Interfaces;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Models.InputModels;

namespace SaltTechStore.Services.Implementation
{
    public class OrdersService : IOrdersService
    {
        IOrdersRepository ordersRepository;

        public OrdersService(IOrdersRepository ordersRepository){
            this.ordersRepository = ordersRepository;
        }

        //get all orders in the system
        public IEnumerable<OrderDto> GetAllOrders(int page, int pageSize){
            List<OrderDto> orders = this.ordersRepository.GetAllOrders().ToList();
            List<OrderDto> result = new List<OrderDto>();

            for(int i = page*pageSize; i < orders.Count() && i < (page+1)*pageSize && i >= 0; i++){
                result.Add(orders.ElementAt(i));
            }

            return result;
        }
        
        //get order from the system given an ID
        public OrderDto GetOrder(int id){
            return this.ordersRepository.GetOrder(id);
        }

        public bool CreateOrders(List<OrderInput> input){
            return true;
        }
    }
}