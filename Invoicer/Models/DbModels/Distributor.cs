using System;
using System.Collections.Generic;

namespace Invoicer.Models.DbModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Distributor
    {
        public Distributor()
        {
            this.Name = new HashSet<Name>();
            this.Address = new HashSet<Address>();
            this.Invoices = new HashSet<Invoice>();
            this.Responsibles = new HashSet<ResponsiblePerson>();
            this.PaymentDetails = new HashSet<PaymentDetail>();
        }

        public int ID { get; set; }
        public string Vat { get; set; }
        public virtual ICollection<Name> Name { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public string ConsultationNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ResponsiblePerson> Responsibles { get; set; }
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; }
        public User CreatedBy { get; set; }
    }
}
