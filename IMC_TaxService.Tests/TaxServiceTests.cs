
using System.IO;
using System.Threading.Tasks;
using IMC_TaxService.Models;
using IMC_TaxService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace IMC_TaxService.Tests
{
    public class TaxServiceTests
    {
        private readonly TaxService _taxService;

        public TaxServiceTests()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var mockLogger = new Mock<ILogger<TaxService>>();
            ILogger<TaxService> logger = mockLogger.Object;

            var taxSericeCalculator = new TaxServiceCalculator(config["Services:TaxJar:ServiceUrl"], config["Services:TaxJar:Authorization"]);
            _taxService = new TaxService(taxSericeCalculator, logger);
        }


        [Fact]
        public async Task GetTaxRateLocationAsync_ReturnsTaxRateLocation()
        {
            var taxRateLocation = await _taxService.GetTaxRateLocationAsync("33472");
            Assert.NotNull(taxRateLocation);
            Assert.Equal("33472", taxRateLocation.Zip);
        }

        [Fact]
        public async Task GetTaxRateOrderAsync_ReturnsTaxRateOrder()
        {
            var taxRateOrder = await _taxService.GetTaxRateOrderAsync("1");
            Assert.Null(taxRateOrder);
        }
    }
    
}
