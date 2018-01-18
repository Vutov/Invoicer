namespace Invoicer.Services
{
    using System.Threading.Tasks;
    using Models.DbModels;

    public interface IVatService
    {
         Task<Client> GetClient(string vat);
    }
}
