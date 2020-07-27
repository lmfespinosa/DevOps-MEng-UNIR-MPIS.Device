#region "Libraries"

using AzureFunctions.Extensions.Swashbuckle;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using MPIS.Device.Function;
using System.Reflection;

#endregion

[assembly: WebJobsStartup(typeof(SwagTokenStartup))]
namespace MPIS.Device.Function
{
    internal class SwagTokenStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            //Register the extension
            builder.AddSwashBuckle(Assembly.GetExecutingAssembly());
        }
    }
}
