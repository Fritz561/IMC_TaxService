using IMC_TaxService.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Moq;

namespace IMC_TaxService.Tests.Fixtures
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private IServiceScope _serviceScope;
        private readonly Mock<ITaxStrategy> _taxServiceMock;
        public CustomWebApplicationFactory()
        {
            _taxServiceMock = new Mock<ITaxStrategy>(MockBehavior.Loose);
        }


        // will automatically reset when accessed via Property
        public Mock<ITaxStrategy> TaxServiceMock
        {
            get
            {
                _taxServiceMock.Reset();
                return _taxServiceMock;
            }
        }

        

        /// <inheritdoc />
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder
                .ConfigureServices(
                    services =>
                    {
                        //services.AddAutoMapper(typeof(DebCoMappingProfile));
                        services.AddSingleton(TaxServiceMock.Object);
                    });

            var testHost = base.CreateHost(builder);

            _serviceScope = testHost.Services.CreateScope();
            var serviceProvider = _serviceScope.ServiceProvider;


            return testHost;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _serviceScope?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}

