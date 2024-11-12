namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

//TODO: Remove update because unused (Gianluca)
public record UpdateAppointmentResource(
    int UserId,
    int CompanyId,
    int ServiceId,
    string Status,
    DateTime ReservationDate,
    string ReservationStartTime,
    string Requirements
);