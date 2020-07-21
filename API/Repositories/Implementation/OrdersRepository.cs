using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using SaltTechStore.Models.DtoModels;
using SaltTechStore.Repositories.Interfaces;
using SaltTechStore.Repositories.Data;

namespace SaltTechStore.Repositories.Implementation
{
    public class OrdersRepository: IOrdersRepository
    {
        private readonly IDBContext dbContext;

        public OrdersRepository(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}