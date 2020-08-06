
using System;
using System.Threading.Tasks;
using IMC_TaxService.Models;
using IMC_TaxService.Services;

namespace IMC_TaxService.TaxServices
{
    // Using the Strategy Pattern to have diffent GetTaxRateLocationAsync and GetTaxRateOrderAsync functions depending on the customer that is consuming the tax service
    // this service is not implemented
    public class OtherTaxService : ITaxService
    {
        public Enums.Services Service { get; }

        public async Task<TaxRateLocation> GetTaxRateLocationAsync(string zip)
        {
            throw new NotImplementedException();
        }

        public async Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId)
        {
            throw new NotImplementedException();
        }
    }
}
