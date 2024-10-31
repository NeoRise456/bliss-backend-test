using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Transform;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class AppointmentResourceFromEntityAssembler
{
    public static AppointmentResource ToResourceFromEntity(Appointment entity)
    {
        return new AppointmentResource(
            entity.Id,
            UserResourceFromEntityAssembler.ToResourceFromEntity(entity.User),
            ServiceResourceFromEntityAssembler.ToResourceFromEntity(entity.Service),
            CompanyResourceFromEntityAssembler.ToResourceFromEntity(entity.Company),
            entity.CreatedDate,
            entity.Status,
            entity.ReservationDate,
            entity.ReservationStartTime,
            entity.Requirements
        );
    }
}