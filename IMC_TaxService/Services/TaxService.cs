using System;
using System.Threading.Tasks;
using IMC_TaxService.Models;
using Microsoft.Extensions.Logging;
using RestSharp;

namespace IMC_TaxService.Services
{
    public class TaxService : ITaxService
    {
        private readonly RestClient _restClient;
        private readonly ILogger _logger;
        private readonly TaxServiceCalculator _taxServiceCalculator;

        public TaxService(TaxServiceCalculator taxServiceCalculator, ILogger logger)
        {
           
            _taxServiceCalculator = taxServiceCalculator ?? throw new ArgumentNullException(nameof(taxServiceCalculator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
      
            _restClient = new RestClient(taxServiceCalculator.ServiceUrl);
        }
        public async Task<TaxRateLocation> GetTaxRateLocationAsync(string zip)
        {
         
            try
            {
                var request = new RestRequest("rates/" + zip, DataFormat.Json);
                request.AddHeader("Authorization", _taxServiceCalculator.Authorization);
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
                request.AddHeader("Authorization", _taxServiceCalculator.Authorization);
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
