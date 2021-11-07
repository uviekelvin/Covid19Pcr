using Covid19Pcr.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Validators
{
    public class CancelBookingCommandValidator : AbstractValidator<CancelBookingCommand>
    {
        public CancelBookingCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Invalid email address");
            RuleFor(x => x.BookingCode).NotEmpty().NotNull().WithMessage("Booking Code is required");
            RuleFor(x => x.BookingCode).MaximumLength(10).MinimumLength(10).
                WithMessage("Booking code must be 10 characters");
        }
    }
}
