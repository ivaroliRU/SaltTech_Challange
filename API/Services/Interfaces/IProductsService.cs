using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Interfaces
{
    public interface IProductsService
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProduct(int id);

        IEnumerable<OrderDto> GetProductOrders(int id);
    }
}