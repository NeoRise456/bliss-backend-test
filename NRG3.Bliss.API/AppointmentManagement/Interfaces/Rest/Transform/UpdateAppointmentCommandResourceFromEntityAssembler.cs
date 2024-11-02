using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class UpdateAppointmentCommandResourceFromEntityAssembler
{
    public static UpdateAppointmentCommand ToCommandFromResource(int appointmentId, UpdateAppointmentResource resource) =>
        new UpdateAppointmentCommand(
            appointmentId,
            resource.UserId,
            resource.CompanyId,
            resource.ServiceId,
            resource.Status,
            resource.ReservationDate,
            resource.ReservationStartTime,
            resource.Requirements
        );
}