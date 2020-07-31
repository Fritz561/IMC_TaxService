using System;
using IMC_TaxService.Services;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace IMC_TaxService.Models
{
    public class TaxServiceCustomerCalculator
    {
        private ITaxService _taxService;
        private ILogger _logger;

        public TaxServiceCustomerCalculator(ILogger logger) 
        {
            _logger = logger;
        }

        // TODO Add logic to retrieve customer tax service and create a new TaxService in SetTaxServiceCustomer
        public void SetTaxServiceCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId) => await _taxService.GetTaxRateOrderAsync(orderId);
        public async Task<TaxRateLocation> GetTaxRateLocationAsync(string zip) => await _taxService.GetTaxRateLocationAsync(zip);

        
    }
}
