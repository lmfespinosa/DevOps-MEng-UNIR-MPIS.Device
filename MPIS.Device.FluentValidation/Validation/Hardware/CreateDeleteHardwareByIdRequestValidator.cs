#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Hardware;
using System;

#endregion

namespace MPIS.Device.FluentValidation.Validation.Hardware
{
    public class CreateDeleteHardwareByIdRequestValidator : AbstractValidator<DeleteHardwareByIdRequest>
    {
        public CreateDeleteHardwareByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("Guid Not Defined");
        }
    }
}
