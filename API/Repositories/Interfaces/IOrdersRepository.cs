using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Repositories.Interfaces
{
    public interface IOrdersRepository
    {
        IEnumerable<OrderDto> GetAllOrders();

        OrderDto GetOrder(int id);
    }
}