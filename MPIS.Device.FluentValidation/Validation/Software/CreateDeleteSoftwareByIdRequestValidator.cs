#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Software;
using System;

#endregion

namespace MPIS.Device.FluentValidation.Validation.Software
{
    public class CreateDeleteSoftwareByIdRequestValidator : AbstractValidator<DeleteSoftwareByIdRequest>
    {
        public CreateDeleteSoftwareByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("Guid Not Defined");
        }
    }
}

