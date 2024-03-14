﻿using FluentValidation;
using HotelProject.EntityLayer.Concrete;
using HotelReservationProject.WebUI.Dtos.GuestDto;

namespace HotelReservationProject.WebUI.ValidationRules.GuestValidationRules
{
	public class CreateGuestValidator:AbstractValidator<CreateGuestDto>
	{

        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Lütfen en az 2 karakter veri girişi yapınız");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız");

			RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");
			RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız");
			RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız");



		}

    }
}
