using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class CreateCompanyCommandResourceFromEntityAssembler
{
    public static CreateCompanyCommand ToCommandFromResource(CreateCompanyResource resource)
    {
        return new CreateCompanyCommand(resource.Name, resource.Ruc, resource.Email, resource.WebsiteUrl, resource.PhoneNumber, resource.Description);
    }
}