namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record CreateAppointmentResource(
    int userId,
    int serviceId,
    int companyId, 
    DateTime reservationDate,
    string status, 
    DateTime date, 
    string time
    );