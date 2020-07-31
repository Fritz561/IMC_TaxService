using System;
using System.Threading.Tasks;
using IMC_TaxService.Models;
using IMC_TaxService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace IMC_TaxService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }


        // TODO:  Refactor to allow user id as a parameter or possibly from the request.headers.
        [HttpGet("zip/{zip}")]
        public async Task<ActionResult<TaxRateLocationResponse>> GetTaxRateByZip(string zip)
        {
            try
            {
                var taxCalculator = new TaxServiceCalculator(_config["Services:TaxJar:ServiceUrl"], _config["Services:TaxJar:Authorization"]);
                var taxService = new TaxService(taxCalculator, _logger);
                var taxRateLocation = await taxService.GetTaxRateLocationAsync(zip);
                return Ok(taxRateLocation);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        // TODO:  Refactor to allow user id as a parameter or possibly from the request.headers.
        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<TaxRateOrderResponse>> GetTaxRateByOrderId(string orderId)
        {
            try
            {
                var taxCalculator = new TaxServiceCalculator(_config["Services:TaxJar:ServiceUrl"], _config["Services:TaxJar:Authorization"]);
                var taxService = new TaxService(taxCalculator, _logger);
                var taxRateOrder = await taxService.GetTaxRateOrderAsync(orderId);
                return Ok(taxRateOrder);

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        //TODO Add post method to create an order on taxjar
        [HttpPost]
        public async Task<ActionResult<TaxRateOrderResponse>> Post([FromBody] TaxRateOrder request)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
