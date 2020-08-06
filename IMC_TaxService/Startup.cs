using IMC_TaxService.TaxServices;
using IMC_TaxService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace IMC_TaxService
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
            
            services.AddControllers();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
         //   services.AddScoped<ITaxService, TaxService>();
    
            services.AddScoped<TaxJarService>();
            services.AddScoped<OtherTaxService>();
            services.AddScoped<ITaxStrategyFactory, TaxStrategyFactory>();
            services.AddScoped<ITaxStrategy, TaxStrategy>();
            services.AddScoped(provider =>
            {
                var factory = (ITaxStrategyFactory)provider.GetService(typeof(ITaxStrategyFactory));
                return factory.Create();
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
