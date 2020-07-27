#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Software;

#endregion

namespace MPIS.Device.FluentValidation.Validation.Software
{
    public class CreateGetSoftwareByMACDeviceRequestValidator : AbstractValidator<GetSoftwareByMACDeviceRequest>
    {
        public CreateGetSoftwareByMACDeviceRequestValidator()
        {
            RuleFor(x => x.MACDevice).NotEmpty();

        }
    }
}
