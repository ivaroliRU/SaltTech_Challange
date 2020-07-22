using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Models.InputModels;

namespace SaltTechStore.Services.Interfaces
{
    public interface IOrdersService
    {
        IEnumerable<OrderDto> GetAllOrders(int page, int pageSize);

        OrderDto GetOrder(int id);

        bool CreateOrders(List<OrderInput> input);
    }
}