using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IMC_TaxService.Models;
using IMC_TaxService.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace IMC_TaxService.TaxServices
{
    // Using the Strategy Pattern to have diffent GetTaxRateLocationAsync and GetTaxRateOrderAsync functions depending on the customer that is consuming the tax service
    // this service is hard coded for Tax Jar Requests
    
    public class TaxJarService : ITaxService
    {
        private readonly RestClient _restClient;
        private readonly ILogger<TaxJarService> _logger;
        private readonly IConfiguration _config;
      

        public TaxJarService( ILogger<TaxJarService> logger, IConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _config = config ?? throw new ArgumentNullException(nameof(config));
       
            _restClient = new RestClient(_config["Services:TaxJar:ServiceUrl"]);
        }

        public Enums.Services Service { get; }

        public async Task<TaxRateLocation> GetTaxRateLocationAsync(string zip)
        {
            try
            {
                var request = new RestRequest("rates/" + zip, DataFormat.Json);
                request.AddHeader("Authorization", _config["Services:TaxJar:Authorization"]);
                var locationResponse = await _restClient.GetAsync<TaxRateLocationResponse>(request);

                return locationResponse.Rate;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
                throw;
            }
        }

        public async Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId)
        {
            try
            {
                var request = new RestRequest("transactions/orders/" + orderId, DataFormat.Json);
                request.AddHeader("Authorization", _config["Services:TaxJar:Authorization"]);
                var orderResponse = await _restClient.GetAsync<TaxRateOrderResponse>(request);

                return orderResponse.Order;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                throw;
            }
        }
    }
}
