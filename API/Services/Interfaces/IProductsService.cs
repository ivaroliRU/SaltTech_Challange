using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaltTechStore.Models.DtoModels;

namespace SaltTechStore.Services.Interfaces
{
    public interface IProductsService
    {
        List<ProductDto> GetAllProducts();
    }
}