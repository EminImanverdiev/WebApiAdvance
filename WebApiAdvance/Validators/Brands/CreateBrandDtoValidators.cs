using FluentValidation;
using WebApiAdvance.Entities.DTOs.Brands;

namespace WebApiAdvance.Validators.Brands
{
    public class CreateBrandDtoValidators:AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidators()
        {
            RuleFor(b=>b.Name)
                .NotEmpty().WithMessage("Ad bos ola bilmez")
                .NotNull().WithMessage("Ad deyerini daxil edin")
                .MinimumLength(3).WithMessage("Ad en azi 3 simvoldan ibaret olmalidir")
                .MaximumLength(30)
                .Must(StartWithA).WithMessage("Ad A herfi ile baslamalidir");

        }




        public bool StartWithA(string name)
        {
            return name.StartsWith("A");
        }
    }
}
