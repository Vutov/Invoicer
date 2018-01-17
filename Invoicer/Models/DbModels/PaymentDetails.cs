namespace Invoicer.Models.DbModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class PaymentDetail
    {
        public int ID { get; set; }
        public string PaymentType { get; set; }
        public string IBAN { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public Distributor Client { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
    }
}
