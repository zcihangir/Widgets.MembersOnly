using Grand.Business.Core.Interfaces.Cms;
using Grand.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Widgets.MembersOnly.Infrastructure.Middleware;

namespace Widgets.MembersOnly
{
    public class StartupApplication : IStartupApplication
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWidgetProvider, MembersOnlyWidgetProvider>();
        }

        public int Priority => 10;

        public void Configure(IApplicationBuilder application, IWebHostEnvironment webHostEnvironment)
        {
            application.UseMiddleware<MembersOnlyMiddleware>();
        }

        public bool BeforeConfigure => false;
    }

}
