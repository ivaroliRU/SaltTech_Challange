using System;
using System.IO;
using System.Collections.Generic;
using SaltTechStore.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SaltTechStore.Repositories.Data
{
    public interface IDBContext : IDisposable
    {
        DbSet<Product> Products{get; set;}
        DbSet<Order> Orders{get; set;}

        int SaveChanges();
        Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Add (object entity);
    }
}