using System;
using System.Configuration;
using System.Web.Http;
using Api.BrilhaMuito.Helper;
using BrilhaMuito.CrossCutting;
using Microsoft.Owin.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Owin;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Swashbuckle.Application;

namespace Api.BrilhaMuito
{
    /// <summary>
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public static void ConfigureWebApi(HttpConfiguration config)
        {
            //Removendo Formato XML
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            //Formantando json para padrão javascript.
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        /// <summary>
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            ConfigureDependencyInjection(config, app);
            ConfigureWebApi(config);
            ConfigureSwagger(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        /// <param name="app"></param>
        public static void ConfigureDependencyInjection(HttpConfiguration config, IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            DependencyInjection.Configure(container);
            app.Use(async (context, next) =>
            {
                using (AsyncScopedLifestyle.BeginScope(container)) { await next(); }
            });
            config.DependencyResolver = new SimpleInjectorDependencyResolver(container);
            container.Verify();
        }


        /// <summary>
        /// </summary>
        /// <param name="config"></param>
        public static void ConfigureSwagger(HttpConfiguration config)
        {
            config.EnableSwagger(c =>
                {
                    c.Schemes(new[] {"http", "https"});
                    c.SingleApiVersion("v1", "Api.BrilhaMuito");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.RootUrl(req => ConfigurationManager.AppSettings["rooturl"]);
                })
                .EnableSwaggerUi(c => { });
        }

        private static string GetXmlCommentsPath()
        {
            return $@"{AppDomain.CurrentDomain.BaseDirectory}\bin\Swagger.xml";
        }


    }
}