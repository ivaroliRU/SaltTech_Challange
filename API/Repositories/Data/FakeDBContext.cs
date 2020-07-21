using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;

namespace SaltTechStore.Repositories.Data
{
    //fake db to get consistent unit tests
    public class FakeDBContext : IDBContext
    {
        //setup test data for the product service
        private static List<Product> products = new List<Product>{
            new Product{
                Id = 1,
                Name = "Test Product 1",
                ImageSource = "adsf",
                price = 1,
                stock = 1
            },
            new Product{
                Id = 2,
                Name = "Test Product 2",
                ImageSource = "adsf",
                price = 1,
                stock = 1
            },
            new Product{
                Id = 3,
                Name = "Test Product 3",
                ImageSource = "adsf",
                price = 1,
                stock = 1
            }
        };

        private static List<Order> orders = new List<Order>{
            new Order{
                Id = 1,
                ProductId = 1
            },
            new Order{
                Id = 2,
                ProductId = 2
            }
        };

        public IEnumerable<Product> Products
        {
            get 
            {
                return products;
            }
        }

        public IEnumerable<Order> Orders
        {
            get 
            {
                return orders;
            }
        }
    }
}