using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaltTechStore.Models.EntityModels
{
    [Table("products")]
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ImageSource {get; set;}
        public int? price {get; set;}
        public int? stock {get; set;}
    }
}