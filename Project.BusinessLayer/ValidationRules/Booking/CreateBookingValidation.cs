using FluentValidation;
using Project.DTO.BookingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.ValidationRules.Booking
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDTO>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.BookingName).NotEmpty().WithMessage("Rezervasyon İsmi alanı zorunludur");
            RuleFor(x => x.BookingPhone).NotEmpty().WithMessage("Rezervasyon Telefonu alanı zorunludur");
            RuleFor(x => x.BookingEmail).NotEmpty().WithMessage("Rezervasyon E-posta alanı zorunludur");
            RuleFor(x => x.BookingEmail).EmailAddress().WithMessage("Geçerli bir E-posta zorunludur");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi Sayısı alanı zorunludur");
            RuleFor(x => x.BookingDate).NotEmpty().WithMessage("Rezervasyon Tarihi alanı zorunludur");
            RuleFor(x => x.BookingName).MinimumLength(2).WithMessage("Rezervasyon İsmi alanı en az 2 karakter olmalıdır").MaximumLength(50).WithMessage("Rezervasyon İsmi alanı en fazla 50 karakter olmalıdır");

        }
    }
}
