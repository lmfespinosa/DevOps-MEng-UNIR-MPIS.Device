#region "Libraries"

using FluentValidation;
using MPIS.Device.AplicationService.DTOs.OperativeSystem;

#endregion

namespace MPIS.Device.FluentValidation.Validation.OperativeSystem
{
    public class CreateGetOperativeSystemByMACDeviceRequestValidator : AbstractValidator<GetOperativeSystemByMACDeviceRequest>
    {
        public CreateGetOperativeSystemByMACDeviceRequestValidator()
        {
            RuleFor(x => x.MACDevice).NotEmpty();

        }
    }
}
