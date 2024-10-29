using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class CreateServiceCommandResourceFromEntityAssembler
{
    public static CreateServiceCommand ToCommandFromResource(CreateServiceResource resource)
    {
        return new CreateServiceCommand(resource.CompanyId, resource.CategoryId, resource.ServiceName, resource.Description, resource.Price, resource.Duration);
    }
}