using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Hardware;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPIS.Device.FluentValidation.Validation.Hardware
{
    public class CreatePostHardwareRequestValidator : AbstractValidator<CreateHardwareRequest>
    {
        public CreatePostHardwareRequestValidator()
        {
            /*RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Office).MaximumLength(5000);
            RuleFor(x => x.Address).MaximumLength(5000);
            RuleFor(x => x.Phone).Matches(@"^\d{7}$").WithMessage("Invalid phone");
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email");
            RuleFor(x => x.Email).NotEmpty();*/
        }
    }
}
