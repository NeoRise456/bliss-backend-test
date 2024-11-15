using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public interface IServiceRepository : IBaseRepository<Service>
{
    Task<IEnumerable<Service>> FindServicesByCompanyIdAsync(int companyId);
    Task<IEnumerable<Service>> FindAllServices();
    Task<Service?> FindServiceById(int serviceId);
    Task<bool> ServiceNameExistsForCompanyAndCategoryAsync(int companyId, int categoryId, string serviceName);
}