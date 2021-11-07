using Covid19Pcr.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid19Pcr.Application.Validators
{
    public class ScheduleTestCommandValidator : AbstractValidator<ScheduleTestCommand>
    {
        public ScheduleTestCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Invalid email address");
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("Firstname is required");
            RuleFor(x => x.SurName).NotEmpty().NotNull().WithMessage("Surname is required");
            RuleFor(x => x.TestTypeId).GreaterThan(0).WithMessage("Test type is required");
            RuleFor(x => x.TestDayId).GreaterThan(0).WithMessage("Test day is required");
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull().WithMessage("PhoneNumber is required");
            RuleFor(x => x.PhoneNumber).MaximumLength(30).WithMessage("Phonenumber must not exceed 20 characters");
        }
    }
}
