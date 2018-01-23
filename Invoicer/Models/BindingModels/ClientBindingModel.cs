namespace Invoicer.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ClientBindingModel
    {
        [Required]
        public int ID { get; set; }
        public string Vat { get; set; }
    }
}
