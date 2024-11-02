using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public class ServiceCategoryResourceFromEntityAssembler
{
    public static ServiceCategoryResource ToResourceFromEntity(Category entity)
    {
        return new ServiceCategoryResource(entity.Id, entity.Name);
    }
}