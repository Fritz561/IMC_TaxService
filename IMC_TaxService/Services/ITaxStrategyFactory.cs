
namespace IMC_TaxService.Services
{
    // Interface for the Factory
    public interface ITaxStrategyFactory
    {
        ITaxService[] Create();
    }
}