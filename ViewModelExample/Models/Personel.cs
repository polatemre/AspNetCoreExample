using System.ComponentModel.DataAnnotations;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.Models
{
    // Entity Model
    public class Personel
    {
        public int Id { get; set; }
        [Required]
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        [Required]
        [StringLength(13)]
        public string Pozisyon { get; set; }
        public int Maas { get; set; }
        [Required]
        public bool MedeniHal { get; set; }

        #region ViewModel'ı Entity Model'a Dönüştürme Yöntemleri
        #region Implicit / Gizli / Bilinçsiz Tür Dönüşümü ile 
        // Personel ->  PersonelCreateViewModel'a dönüşüm sağlanır.
        //public static implicit operator PersonelCreateViewModel(Personel model)
        //{
        //    return new PersonelCreateViewModel
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi
        //    };
        //}

        //// PersonelCreateViewModel ->  Personel'a dönüşüm sağlanır.
        //public static implicit operator Personel(PersonelCreateViewModel model)
        //{
        //    return new Personel
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi
        //    };
        //}
        #endregion
        #region Explicit / Açık / Bilinçli Tür Dönüşümü ile 
        // Personel ->  PersonelCreateViewModel'a dönüşüm sağlanır.
        public static explicit operator PersonelCreateViewModel(Personel model)
        {
            return new PersonelCreateViewModel
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi
            };
        }

        // PersonelCreateViewModel ->  Personel'a dönüşüm sağlanır.
        public static explicit operator Personel(PersonelCreateViewModel model)
        {
            return new Personel
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi
            };
        }
        #endregion
        #endregion
    }
}
