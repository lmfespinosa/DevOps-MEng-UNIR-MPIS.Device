#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Device;

#endregion

namespace MPIS.Device.FluentValidation.Validation.Device
{
    public class CreatePostDeviceRequestValidator : AbstractValidator<CreateDeviceRequest>
    {
        public CreatePostDeviceRequestValidator()
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
