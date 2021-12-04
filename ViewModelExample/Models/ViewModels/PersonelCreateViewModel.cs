using System.ComponentModel.DataAnnotations;

namespace ViewModelExample.Models.ViewModels
{
    public class PersonelCreateViewModel
    {
        //ViewModel'da sadece taşınacak verinin propertyleri temsil edilir.
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
    }
}
