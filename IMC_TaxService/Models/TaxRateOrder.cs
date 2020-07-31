using System;
using System.Collections.Generic;

namespace IMC_TaxService.Models
{
    public class TaxRateOrder
    {
        public string Transaction_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Transaction_Date { get; set; }
        public string Provider { get; set; }
        public string To_Country { get; set; }
        public string To_Zip { get; set; }
        public string To_State { get; set; }
        public string To_City { get; set; }
        public string To_Street { get; set; }
        public string Amount { get; set; }
        public string Shipping { get; set; }
        public string Sales_tax { get; set; }
        public List<TaxRateOrderLineItem> Line_Items { get; set; }
    }
}
