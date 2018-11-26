using Newtonsoft.Json;
using System.Net.Http.Formatting;
using System.Web.Http;
using WebApi.Comp.Filters;

namespace WebApi.Comp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new AuthorizeAttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Filters.Add(new ApiExceptionFilter());
            config.MessageHandlers.Add(new WrapperHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var jsonFormatter = new JsonMediaTypeFormatter();
            var settings = jsonFormatter.SerializerSettings;
            settings.NullValueHandling = NullValueHandling.Ignore;
        }
    }
}
