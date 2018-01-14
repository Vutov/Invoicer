﻿namespace Invoicer.Models.DocModels
{
    using Invoicer.Models.DbModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Client
    {
        public int ID { get; set; }
        public string Vat { get; set; }
        public bool EnterManualy { get; set; }
        public DateTime RequestDate { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Address> Address { get; set; }
        public string ConsultationNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public Invoice Invoice { get; set; }
    }
}