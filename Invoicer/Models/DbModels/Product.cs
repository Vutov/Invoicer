using System;

namespace Invoicer.Models.DbModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Discount { get; set; }
        public double PriceWithDiscout { get; set; }
        public double TotalAmount { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public Invoice Invoice { get; set; }
    }
}
