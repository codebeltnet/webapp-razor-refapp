using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Codebelt.Bootstrapper.Web;
using Cuemon.AspNetCore.Razor.TagHelpers;
using Cuemon.Extensions.AspNetCore.Configuration;
using Cuemon.Extensions.AspNetCore.Diagnostics;
using Cuemon.Extensions.AspNetCore.Http.Headers;
using Cuemon.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Codebelt.WebApp.Razor
{
    public class Startup : WebStartup
    {
        public Startup(IConfiguration configuration, IHostEnvironment environment) : base(configuration, environment)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppTagHelperOptions>(Configuration.GetSection("TagHelperOptions:App"));
            services.Configure<CdnTagHelperOptions>(Configuration.GetSection("TagHelperOptions:Cdn"));
            services.AddResponseCaching();
            services.AddResponseCompression();
            services.AddAssemblyCacheBusting();
            services.AddServerTiming();
            services.AddRazorPages();
        }

        public override void Configure(IApplicationBuilder app, ILogger logger)
        {
            if (Environment.IsLocalDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseServerTiming();

            app.UseResponseCompression();

            app.UseResponseCaching();

            app.UseCacheControl(o => o.Validators.Add(new EntityTagCacheableValidator()));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
