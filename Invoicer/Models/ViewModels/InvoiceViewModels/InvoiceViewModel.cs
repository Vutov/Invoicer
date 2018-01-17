namespace Invoicer.Models.ViewModels.InvoiceViewModels
{
    using System;
    using System.Collections.Generic;
    using DbModels;
    using DocModels;

    public class InvoiceViewModel
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public Client Client { get; set; }
        public Distributor Distributor { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public double Vat { get; set; }
    }
}
