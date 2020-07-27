#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.Hardware;


#endregion

namespace MPIS.Device.FluentValidation.Validation.Hardware
{
    public class CreateGetHardwareByMACDeviceRequestValidator : AbstractValidator<GetHardwareByMACDeviceRequest>
    {
        public CreateGetHardwareByMACDeviceRequestValidator()
        {
            RuleFor(x => x.MACDevice).NotEmpty();
            
        }
    }
}
