namespace Invoicer.Models.ViewModels.InvoiceViewModels
{
    using System.Collections.Generic;

    public class ClientViewModel
    {
        public int ID { get; set; }
        public string Vat { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Address { get; set; }
        public string ConsultationNumber { get; set; }
        public string ResponsiblePerson { get; set; }
    }
}
