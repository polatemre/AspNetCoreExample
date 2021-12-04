using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModelExample.Business.Reflection;
using ViewModelExample.Models;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.Controllers
{
    public class PersonelController : Controller
    {
        #region AutoMapper
        public IMapper Mapper { get; }

        public PersonelController(IMapper mapper)
        {
            Mapper = mapper;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        //{
        //    //...
        //    return View();
        //}

        #region Bir Model'in View'de ki Etkileşimine Uygun Parçasını Temsil Etme
        public IActionResult Listele()
        {
            // Sadece view kısmında kullanılanacak değerleri ViewModel kullanarak göndeririz.

            List<PersonelListeleViewModel> personeller = new List<Personel>
            {
                new Personel{ Adi = "A", Soyadi = "B"},
                new Personel{ Adi = "A1", Soyadi = "B"},
                new Personel{ Adi = "A2", Soyadi = "B"},
                new Personel{ Adi = "A3", Soyadi = "B"},
                new Personel{ Adi = "A4", Soyadi = "B"},
                new Personel{ Adi = "A5", Soyadi = "B"}
            }.Select(p => new PersonelListeleViewModel
            {
                Adi = p.Adi,
                Soyadi = p.Soyadi,
                Pozisyon = p.Soyadi
            }).ToList();
            return View(personeller);
        }
        #endregion
        #region ViewModel ile Birden Fazla Nesneyi Tek Bir Nesneye Bağlama
        public IActionResult Get()
        {
            var nesne = (new Personel(), new Urun(), new Musteri());
            return View(nesne);
        }
        #endregion

        #region ViewModel'ı Entity Model'a Dönüştürme Yöntemleri
        #region Manuel Dönüştürme - Tercih Edilmez
        //[HttpPost]
        //public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        //{
        //    Personel p = new Personel()
        //    {
        //        Adi = personelCreateViewModel.Adi,
        //        Soyadi = personelCreateViewModel.Soyadi
        //    };

        //    return View();
        //}
        #endregion
        #region Implicit Operator Overload ile Dönüştürme
        // Model üzerinde yapılır, ileri düzey programlama bilgisi gerektirir.
        //[HttpPost]
        //public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        //{
        //    // Polimorfizm ilişkisi olmaksızın implicit ve explicit operatörleri ile Personel referansına atabilmekteyiz.
        //    Personel personel = personelCreateViewModel;
        //    PersonelCreateViewModel vm = personel;

        //    return View();
        //}
        #endregion
        #region Explicit Operator Overload ile Dönüştürme
        //[HttpPost]
        //public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        //{
        //    // Polimorfizm ilişkisi olmaksızın implicit ve explicit operatörleri ile Personel referansına atabilmekteyiz.
        //    Personel personel = (Personel)personelCreateViewModel;
        //    PersonelCreateViewModel vm = (PersonelCreateViewModel)personel;

        //    return View();
        //}
        #endregion
        #region Reflection ile Dönüştürme
        // Herhangi bir sınıf/struct/ınterface'in içerisine girip ilgili tür içerisinde programatik olarak tarama yapmamızı sağlayan ve memberlar üzerinde işlemler gerçekleştirmemizi sağlayan ileri düzey bir tekniktir.

        //[HttpPost]
        //public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        //{
        //    Personel p = TypeConversion.Conversion<PersonelCreateViewModel, Personel>(personelCreateViewModel);

        //    PersonelListeleViewModel personelListeleViewModel = TypeConversion.Conversion<Personel, PersonelListeleViewModel>(new Personel
        //    {
        //        Adi = "asdasd",
        //        Soyadi = "asdasd"
        //    });

        //    return View();
        //}
        #endregion
        #region Auto Mapper ile Dönüştürme
        [HttpPost]
        public IActionResult Index(PersonelCreateViewModel personelCreateViewModel)
        {
            Personel p = Mapper.Map<Personel>(personelCreateViewModel);
            PersonelCreateViewModel p2 = Mapper.Map<PersonelCreateViewModel>(p);

            return View();
        }
        #endregion
        #endregion
    }
}
