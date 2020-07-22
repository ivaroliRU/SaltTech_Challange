using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaltTechStore.Models.EntityModels
{
    [Table("orders")]
    public class Order
    {
        public int Id {get; set;}
        public int ProductId {get; set;}
    }
}