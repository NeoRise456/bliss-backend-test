namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

public record CreateAppointmentCommand(
    int UserId,
    int ServiceId,
    int CompanyId,
    DateTime ReservationDate,
    string Status,
    DateTime Date,
    string Time
);