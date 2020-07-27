#region "Libraries"

using System;

#endregion

namespace MPIS.Device.AplicationService.DTOs.User
{
    public class CreateUserRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
    }
}
