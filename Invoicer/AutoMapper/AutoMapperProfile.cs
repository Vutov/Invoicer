namespace Invoicer.AutoMapper
{
    using System;
    using System.Linq;
    using global::AutoMapper;
    using Models.DbModels;
    using Models.DocModels;
    using Models.ViewModels.InvoiceViewModels;

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<DocProduct, Product>()
                .ForMember(x => x.ProductID, opts => opts.MapFrom(x => x.ID))
                .ForMember(x => x.ID, opts => opts.Ignore());

            this.CreateMap<Distributor, Client>();
            this.CreateMap<Client, ClientViewModel>()
                .ForMember(x => x.Address, opts => opts.MapFrom(
                    x => x.Address
                        .Split('|', StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                ));
        }
    }
}
