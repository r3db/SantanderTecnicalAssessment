using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Santander
{
    public class Startup : IStartup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);
            ConfigureMvc(services);

            return services.BuildServiceProvider();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
        
        protected virtual void ConfigureDependencies(IServiceCollection services)
        {
            services.AddSingleton<IHackerNewsApi, HackerNewsApi>();
        }

        private static void ConfigureMvc(IServiceCollection services)
        {
            services.AddMvc(o =>
            {
                // Note: I'll not be implementing any kind of authentication/authorization!
                //o.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            });

            services.AddApiVersioning();
        }
    }
}