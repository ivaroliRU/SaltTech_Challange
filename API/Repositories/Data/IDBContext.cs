using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using System.Linq;

namespace SaltTechStore.Repositories.Data
{
    public interface IDBContext
    {
        IEnumerable<Product> Products{get;}

        IEnumerable<Order> Orders{get;}
    }
}