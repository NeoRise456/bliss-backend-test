using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.QueryServices;

public class ServiceQueryService(IServiceRepository serviceRepository) : IServiceQueryService
{
    public async Task<Service?> Handle(GetServiceByIdQuery query)
    {
        return await serviceRepository.FindByIdAsync(query.ServiceId);
    }
    
    public async Task<IEnumerable<Service>> Handle(GetAllServicesQuery query)
    {
        return await serviceRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Service>> Handle(GetAllServicesByCompanyIdQuery query)
    {
        return await serviceRepository.FindServicesByCompanyIdAsync(query.CompanyId);
    }
}