#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;
using System;

#endregion

namespace MPIS.Device.FluentValidation.Validation.OperativeSystem
{
    public class CreateDeleteOperativeSystemByIdRequestValidator : AbstractValidator<DeleteOperativeSystemByIdRequest>
    {
        public CreateDeleteOperativeSystemByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).NotEqual(default(Guid)).WithMessage("Guid Not Defined");
        }
    }
}
