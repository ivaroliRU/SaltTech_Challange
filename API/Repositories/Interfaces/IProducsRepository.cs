using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        IEnumerable<ProductDto> GetAllProducts();

        ProductDto GetProduct(int id);

        IEnumerable<OrderDto> GetProductOrders(int id);

        bool CreateOrder(int id);
    }
}