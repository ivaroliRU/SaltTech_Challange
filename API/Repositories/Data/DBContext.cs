using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SaltTechStore.Models.EntityModels;

namespace SaltTechStore.Repositories.Data
{
    public class DBContext : DbContext, IDBContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DBContext(DbContextOptions<DBContext> options) 
            : base(options) { }
    
    }
}