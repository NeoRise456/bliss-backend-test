using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(
            entity.Id,
            entity.FirstName,
            entity.LastName,
            entity.Password,
            entity.Email,
            entity.Phone,
            entity.Dni,
            entity.Address,
            entity.City,
            entity.BirthDate
        );
    }
}