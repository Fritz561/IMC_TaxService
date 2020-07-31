using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using IMC_TaxService.Controllers;
using Xunit;
using IMC_TaxService.Models;
using Microsoft.AspNetCore.Mvc;


namespace IMC_TaxService.Tests
{
    public class TaxServiceControllerTests 
    {
        private readonly TaxCalculatorController _controller;

        public TaxServiceControllerTests()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var mockLogger = new Mock<ILogger<TaxCalculatorController>>();
            ILogger<TaxCalculatorController> logger = mockLogger.Object;

            _controller = new TaxCalculatorController(logger, config);
        }

        [Fact]
        public async Task GetTaxRateByZip_OkResponse()
        {

            var response = await _controller.GetTaxRateByZip("33472");

            Assert.NotNull(response);

            if (response.Result is OkObjectResult ok)
            {
                Assert.Equal(ok.StatusCode, (int) HttpStatusCode.OK);

                var taxRateLocation = (TaxRateLocation) ok.Value;
                Assert.Equal("33472", taxRateLocation.Zip);
            }
        }

        [Fact]
        public async Task GetTaxRateByOrder_OkResponse()
        {
              
            var response = await _controller.GetTaxRateByOrderId("1");

            Assert.NotNull(response);
            if (response.Result is OkObjectResult ok) Assert.Equal(ok.StatusCode, (int) HttpStatusCode.OK);
        }
    }
}
