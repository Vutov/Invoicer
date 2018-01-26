namespace Invoicer.Models.DbModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using DocModels;

    public class Invoice
    {
        public Invoice()
        {
            this.Products = new HashSet<Product>();
        }

        public int ID { get; set; }
        public string DocumentID { get; set; }
        public DateTime DocumentDate { get; set; }
        public Client Client { get; set; }
        public Distributor Distributor { get; set; }
        public CurrencyEnum CurrencyID { get; set; }
        public string Weight { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public User CreatedBy { get; set; }
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
