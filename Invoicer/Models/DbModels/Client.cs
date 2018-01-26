namespace Invoicer.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        public Client()
        {
            this.Invoices = new HashSet<Invoice>();
        }

        public int ID { get; set; }
        public string Vat { get; set; }
        public DateTime RequestDate { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ConsultationNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public string ResponsiblePerson { get; set; }
        public User CreatedBy { get; set; }
    }
}
