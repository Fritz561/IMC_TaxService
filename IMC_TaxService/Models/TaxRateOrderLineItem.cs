
namespace IMC_TaxService.Models
{
    public class TaxRateOrderLineItem
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
        public string Product_Identifier { get; set; }
        public string Description { get; set; }
        public string Unit_Price { get; set; }
        public string Discount { get; set; }
        public string Sales_Tax { get; set; }
    }
}
