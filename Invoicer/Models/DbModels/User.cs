namespace Invoicer.Models.DbModels
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public User()
        {
            this.Invoices = new HashSet<Invoice>();
        }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
        public virtual ICollection<Distributor> Distributors { get; set; }
    }
}
