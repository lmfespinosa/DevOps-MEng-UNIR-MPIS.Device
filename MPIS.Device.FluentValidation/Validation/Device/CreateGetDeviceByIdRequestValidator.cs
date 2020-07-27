#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Device;
using System;

#endregion

namespace MPIS.Device.FluentValidation.Validation.Device
{
    public class CreateGetDeviceByIdRequestValidator : AbstractValidator<GetDeviceByIdRequest>
    {
        public CreateGetDeviceByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("Guid Not Defined");
        }
    }
}
