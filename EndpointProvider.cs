using Grand.Infrastructure.Endpoints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Widgets.MembersOnly
{
    public partial class EndpointProvider : IEndpointProvider
    {
        public void RegisterEndpoint(IEndpointRouteBuilder endpointRouteBuilder)
        {
            //PaymentInfo
            endpointRouteBuilder.MapControllerRoute("Plugin.MembersOnly",
                 "Plugins/MembersOnly/Check",
                 new { controller = "MembersOnly", action = "Check", area = "" }
            );
        }
        public int Priority => 0;

    }
}
