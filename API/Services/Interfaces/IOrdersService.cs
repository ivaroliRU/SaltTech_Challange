using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetAllOrders();

        OrderDto GetOrder(int id);
    }
}