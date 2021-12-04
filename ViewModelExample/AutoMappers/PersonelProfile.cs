using AutoMapper;
using ViewModelExample.Models;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.AutoMappers
{
    public class PersonelProfile : Profile
    {
        public PersonelProfile()
        {
            CreateMap<Personel, PersonelCreateViewModel>();
            CreateMap<PersonelCreateViewModel, Personel>();
        }
    }
}
