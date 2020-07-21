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
    public class OrderServiceTests
    {
        IOrdersService ordersService;

        public OrderServiceTests(){
            //setting up env for testing (switching out real db context with the fake one)
            IDBContext dbContext = new FakeDBContext();
            IOrdersRepository ordersRepository = new OrdersRepository(dbContext);
            ordersService = new OrdersService(ordersRepository);
        }
    }
}