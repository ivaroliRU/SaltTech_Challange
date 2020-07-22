using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaltTechStore.Models.InputModels
{
    public class OrderInput
    {
        public int ProductId {get; set;}
    }
}