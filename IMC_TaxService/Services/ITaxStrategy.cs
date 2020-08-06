using System.Threading.Tasks;
using IMC_TaxService.Models;

namespace IMC_TaxService.Services
{
    //interface which the calling code will consume. The code does not care about the implementation of the classes and has a level of abstraction to allow for single responsibility
    public interface ITaxStrategy
    {
        Task<TaxRateLocation> GetTaxRateLocationAsync(string zip, Enums.Services service);

        Task<TaxRateOrder> GetTaxRateOrderAsync(string orderId, Enums.Services service);
    }
}
