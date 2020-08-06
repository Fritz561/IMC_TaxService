using IMC_TaxService.TaxServices;

namespace IMC_TaxService.Services
{
    public class TaxStrategyFactory : ITaxStrategyFactory
    {
        private readonly TaxJarService _taxJarService;
        private readonly OtherTaxService _otherTaxService;

        public TaxStrategyFactory(
            TaxJarService taxJarService,
            OtherTaxService otherTaxService)
        {
            _taxJarService = taxJarService;
            _otherTaxService = otherTaxService;
        }

        public ITaxService[] Create() => new ITaxService[] {_taxJarService, _otherTaxService};
    }
}