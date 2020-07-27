#region "Libraries"

using System;

#endregion

namespace MPIS.Device.Function.Integration.Tests.Models
{
    public class CreatedUserEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Office { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
