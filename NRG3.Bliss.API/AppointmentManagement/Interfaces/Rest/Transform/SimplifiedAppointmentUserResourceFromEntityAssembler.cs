using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class SimplifiedAppointmentUserResourceFromEntityAssembler
{
    public static SimplifiedUserResource ToResourceFromEntity(User entity)
    {
        return new SimplifiedUserResource(entity.Id, entity.FirstName, entity.LastName, entity.Dni);
    }
}