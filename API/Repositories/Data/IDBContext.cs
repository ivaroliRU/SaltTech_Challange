using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;

namespace SaltTechStore.Repositories.Data
{
    public interface IDBContext
    {
        List<Product> Products{get;}
    }
}