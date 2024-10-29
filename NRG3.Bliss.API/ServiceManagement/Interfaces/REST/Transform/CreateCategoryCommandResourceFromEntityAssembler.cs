using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class CreateCategoryCommandResourceFromEntityAssembler
{
    public static CreateCategoryCommand ToCommandFromResource(CreateCategoryResource resource)
    {
        return new CreateCategoryCommand(resource.Name, resource.Description);
    }
}