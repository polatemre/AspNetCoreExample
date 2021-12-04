using Asp.NET_Core_Empty_to_MVC.Models.ModelMetadataTypes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Asp.NET_Core_Empty_to_MVC.Models
{
    //[ModelMetadataType(typeof(ProductMetadata))] //Validasyonlarını bu sınıftan alacağını bildirdik.
    public class Product
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
    }
}
