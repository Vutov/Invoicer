﻿namespace Invoicer.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        public Client()
        {
            this.Name = new HashSet<Name>();
            this.Address = new HashSet<Address>();
            this.Invoices = new HashSet<Invoice>();
            this.Responsibles = new HashSet<ResponsiblePerson>();
        }

        public int ID { get; set; }
        public string Vat { get; set; }
        public bool EnterManualy { get; set; }
        public DateTime RequestDate { get; set; }
        public virtual ICollection<Name> Name { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public string ConsultationNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<ResponsiblePerson> Responsibles { get; set; }
    }
}
