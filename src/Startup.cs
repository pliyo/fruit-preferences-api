using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

namespace fruit_preferences_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddControllersAsServices();

            services.AddHealthChecks()
                .AddCheck("Health",
                () => HealthCheckResult.Healthy("Healthy"), tags: new[] { "health" });
            services.AddHealthChecks()
                    .AddCheck("Ready", () =>
                        HealthCheckResult.Healthy("Ready"), tags: new[] { "ready" }
                    );
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/status/ready", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("ready"),
                    ResponseWriter = async (context, healthReport) =>
                    {
                        await context.Response.WriteAsync("ready!");
                    }
                });

                endpoints.MapHealthChecks("/status/health", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("health")
                });
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
