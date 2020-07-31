using System.Threading.Tasks;
using IMC_TaxService.Models;

namespace IMC_TaxService.Services
{
    public interface ITaxService
    {
        Task<TaxRateLocation> GetTaxRateLocationAsync(string zip);
        Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId);
    }
}
