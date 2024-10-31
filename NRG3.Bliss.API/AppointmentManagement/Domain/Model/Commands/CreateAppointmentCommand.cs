namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

public record CreateAppointmentCommand( int UserId, int CompanyId, int ServiceId, string Status, DateTime ReservationDate, string ReservationStartTime, string Requirements);