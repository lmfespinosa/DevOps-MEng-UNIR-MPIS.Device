#region "Libraries"

using Microsoft.Extensions.Logging;
using MPIS.Device.Function.Unit.Tests.Services;
using NUnit.Framework;

#endregion

namespace MPIS.Device.Function.Unit.Tests.ControllerTests
{
    public class UnitTestUserController : TestServiceBase
    {
        #region "Atributes"

        private ILogger _logger;

        #endregion

        #region "Constructor"

        [SetUp]
        public void Setup()
        {
            _logger = TestLogger.Create<ILogger>();
            //_userPublisher = MockUserPublisher.Create();

        }

        #endregion
    }
}
