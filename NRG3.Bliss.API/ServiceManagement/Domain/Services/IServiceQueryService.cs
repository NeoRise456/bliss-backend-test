using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface IServiceQueryService
{
    Task<IEnumerable<Service>> Handle(GetAllServicesQuery query);
    Task<Service> Handle(GetServiceByIdQuery query);
    Task<IEnumerable<Service>> Handle(GetServicesByCompanyId query);
}