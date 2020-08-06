using System.Threading.Tasks;
using IMC_TaxService.Models;

namespace IMC_TaxService.Services
{
    //Interface which defines the service type and the functions for each implementation
    public interface ITaxService
    {
        Enums.Services Service { get; }

        Task<TaxRateLocation> GetTaxRateLocationAsync(string zip);

        Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId);
    }
}
