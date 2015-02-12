using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.ConfigurationModel;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Diagnostics;

namespace KWebStartup
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.UseServices(services =>
            {
                services.AddMvc();
                services.AddTransient<IConfiguration>(i => Configuration);
            });
            
            app.UseBrowserLink();
            app.UseErrorPage(ErrorPageOptions.ShowAll);

            // Add MVC to the request pipeline
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });

                routes.MapRoute(
                    name: "api",
                    template: "{controller}/{id?}");
            });
        }
    }
}
