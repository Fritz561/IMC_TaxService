using System;
using System.Linq;
using System.Threading.Tasks;
using IMC_TaxService.Models;

namespace IMC_TaxService.Services
{
    public class TaxStrategy : ITaxStrategy
    {
        private readonly ITaxService[] _services;

        // Strategy Pattern requires to have the ITaxService injected
        public TaxStrategy(ITaxService[] services)
        {
            _services = services;
        }

        //task looks for the first service which matches the service provided and executes
        public Task<TaxRateLocation> GetTaxRateLocationAsync(string zip, Enums.Services service)
        {
            return _services.FirstOrDefault(x => x.Service == service)?.GetTaxRateLocationAsync(zip) ??
                   throw new ArgumentNullException(nameof(service));
        }

        //task looks for the first service which matches the service provided and executes
        public Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId, Enums.Services service)
        {
            return _services.FirstOrDefault(x => x.Service == service)?.GetTaxRateOrderAsync(orderId) ??
                   throw new ArgumentNullException(nameof(service));
        }
    }
}
