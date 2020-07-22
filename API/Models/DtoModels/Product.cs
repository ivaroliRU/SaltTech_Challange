using System;

namespace SaltTechStore.Models.DtoModels
{
    public class ProductDto
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ImageSource {get; set;}
        public int? price {get; set;}
        public int? stock {get; set;}
    }
}