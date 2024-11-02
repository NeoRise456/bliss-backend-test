using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;
public static class SimplifiedReviewAppointmentFromEntityAssembler
{
    public static SimplifiedAppointmentResource ToResourceFromEntity(Appointment appointment)
    {
        if (appointment.Service == null)
        {
            throw new ArgumentException("Service cannot be null", nameof(appointment.Service));
        }

        if (appointment.Company == null)
        {
            throw new ArgumentException("Company cannot be null", nameof(appointment.Company));
        }

        var simplifiedServiceResource = SimplifiedAppointmentServiceResourceFromEntityAssembler.ToResourceFromEntity(appointment.Service);
        var simplifiedCompanyResource = SimplifiedCompanyAppointmentFromEntityAssembler.ToResourceFromEntity(appointment.Company);

        return new SimplifiedAppointmentResource(
            simplifiedServiceResource.ServiceName,
            simplifiedCompanyResource.Name,
            appointment.ReservationStartTime,
            appointment.UserId
        );
    }
}