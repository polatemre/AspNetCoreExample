using System.ComponentModel.DataAnnotations;

namespace Asp.NET_Core_Empty_to_MVC.Models.ModelMetadataTypes
{
    /* Burası product modelde validation uygulanan propertyleri tutacaktır.
     * Böylece validation işlemlerine farklı bir classta tanımlayarak Single Responsibility Principle uymuş oluyoruz.
     */
    public class ProductMetadata
    {
        [Required(ErrorMessage = "Lütfen product name'i giriniz.")]
        [StringLength(100, ErrorMessage = "Lütfen product name'i en fazla 100 karakter giriniz.")]
        public string ProductName { get; set; }

        [EmailAddress(ErrorMessage = "Lütfen doğru bir email adresi giriniz.")]
        public string Email { get; set; }
    }
}
