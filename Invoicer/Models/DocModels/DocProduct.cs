namespace Invoicer.Models.DocModels
{
    public class DocProduct
    {
        // TODO Table place in attr
        public int ID { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public string Discount { get; set; }
        public double PriceWithDiscout { get; set; }
        public double TotalAmount { get; set; }
    }
}
