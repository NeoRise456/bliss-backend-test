using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

public static class SimplifiedReviewAppointmentFromEntityAssembler
{
    public static SimplifiedAppointmentResource ToResourceFromEntity(Appointment appointment)
    {
        return new SimplifiedAppointmentResource(
            appointment.ServiceId,
            appointment.CompanyId,
            appointment.ReservationStartTime,
            appointment.UserId
        );
    }
}