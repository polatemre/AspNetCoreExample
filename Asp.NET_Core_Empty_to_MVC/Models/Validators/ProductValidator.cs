using FluentValidation;

namespace Asp.NET_Core_Empty_to_MVC.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Email).NotNull().WithMessage("Email boş olamaz!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen doğru bir email giriniz!");

            // her iki durumu da veya mantığıyla değerlendirir.
            RuleFor(x => x.ProductName).NotNull().WithMessage("Lütfen product name'i boş geçmeyiniz!").NotEmpty().WithMessage("Lütfen product name'i boş geçmeyiniz!"); 
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("Lütfen product name'i 100 karakterden fazla girmeyiniz!");
        }
    }
}
