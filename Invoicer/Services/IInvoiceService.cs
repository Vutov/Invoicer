namespace Invoicer.Services
{
    using System.IO;
    using Models.DbModels;

    public interface IInvoiceService
    {
        Invoice CreateInvoice(Stream stream);
    }
}
