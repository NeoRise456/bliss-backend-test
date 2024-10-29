using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

public static class CompanyResourceFromEntityAssembler
{
    public static CompanyResource ToResourceFromEntity(Company entity)
    {
        return new CompanyResource(entity.Id, entity.Name, entity.Ruc, entity.Email, entity.WebsiteUrl, entity.PhoneNumber, entity.Description);
    }
}