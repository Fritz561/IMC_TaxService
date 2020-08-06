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
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly IConfiguration _config;
        private readonly ITaxStrategy _taxStrategy;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IConfiguration config, ITaxStrategy taxStrategy)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _taxStrategy = taxStrategy ?? throw new ArgumentNullException(nameof(taxStrategy));

        }


        // TODO:  Refactor to allow user id as a parameter or possibly from the request.headers.
        [HttpGet("zip/{zip}")]
        public async Task<ActionResult<TaxRateLocationResponse>> GetTaxRateByZip(string zip)
        {
            try
            {
                // TODO: add logic to check customer info to determine which strategy to use, ie: Enums.Services.TaxJar or Enums.Services.OtherTax 
                var taxRateLocation = await _taxStrategy.GetTaxRateLocationAsync(zip,Enums.Services.TaxJar);
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
                // TODO: add logic to check customer info to determine which strategy to use, ie: Enums.Services.TaxJar or Enums.Services.OtherTax 
                var taxRateOrder = await _taxStrategy.GetTaxRateOrderAsync(orderId, Enums.Services.TaxJar);
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
