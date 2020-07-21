using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;

namespace SaltTechStore.Repositories.Data
{
    public class DBContext : IDBContext
    {
        private static List<Product> products;

        public DBContext()
        {
        }

        public List<Product> Products
        {
            get 
            {
                return products;
            }
        }
    }
}