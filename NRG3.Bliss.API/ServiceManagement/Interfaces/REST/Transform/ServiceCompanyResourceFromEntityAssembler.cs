using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class ServiceCompanyResourceFromEntityAssembler
{
    public static ServiceCompanyResource ToResourceFromEntity(Company entity)
    {
        return new ServiceCompanyResource(entity.Id, entity.Name);
    }
}