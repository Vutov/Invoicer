using System;

namespace Invoicer.Models.DbModels
{
    using System.ComponentModel.DataAnnotations.Schema;
    using DocModels;

    public class Name
    {
        public int ID { get; set; }
        public string Line { get; set; }
        public Client Client { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
    }
}
