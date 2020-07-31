
namespace IMC_TaxService.Models
{
    public class TaxServiceCalculator
    {
        public string ServiceUrl { get; set; }
        public string Authorization { get; set; }

        public TaxServiceCalculator(string serviceUrl, string authorization)
        {
            ServiceUrl = serviceUrl;
            Authorization = authorization;
        }

    }
}
