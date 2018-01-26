using System;

namespace Invoicer.Models.DbModels
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class ResponsiblePerson
    {
        public int ID { get; set; }
        public string Data { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }
        public LanguageEnum Language { get; set; }
    }
}
