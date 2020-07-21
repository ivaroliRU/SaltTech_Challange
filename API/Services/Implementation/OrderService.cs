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
    }
}