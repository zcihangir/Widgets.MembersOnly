using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Widgets.MembersOnly.Infrastructure.Middleware
{
    public class MembersOnlyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly MembersOnlyWidgetSettings _membersOnlyWidgetSettings;

        public MembersOnlyMiddleware(
            RequestDelegate next,
            MembersOnlyWidgetSettings membersOnlyWidgetSettings)
        {
            _next = next;
            _membersOnlyWidgetSettings = membersOnlyWidgetSettings;
        }

        public async Task InvokeAsync(
            HttpContext context)
        {
            bool isStaticFile = !String.IsNullOrEmpty(System.IO.Path.GetExtension(context.Request.Path));

            if (context.Request.Cookies.ContainsKey(".Grand.Authentication") || 
                context.Request.Cookies.ContainsKey(".Member") || 
                context.Request.Path.ToString().Contains("MembersOnly") || 
                context.Request.Path.ToString().Contains("Plugins") || 
                !_membersOnlyWidgetSettings.MembersOnlyAccessEnabled ||
                isStaticFile)
            {
                await _next(context);
                return;
            }

            var viewResult = new ViewResult() {
                ViewName = "~/Views/WidgetsMembersOnly/Index.cshtml"
            };

            var viewDataDictionary = new ViewDataDictionary(
                new EmptyModelMetadataProvider(),
                new ModelStateDictionary());

            viewDataDictionary.Model = null;//your model
            viewResult.ViewData = viewDataDictionary;

            var executor = context.RequestServices
                .GetRequiredService<IActionResultExecutor<ViewResult>>();
            var routeData = context.GetRouteData() ?? new RouteData();
            var actionContext = new ActionContext(
                context, 
                routeData,
                new Microsoft.AspNetCore.Mvc.Abstractions.ActionDescriptor());

            await executor.ExecuteAsync(actionContext, viewResult);
        }
    }
}
