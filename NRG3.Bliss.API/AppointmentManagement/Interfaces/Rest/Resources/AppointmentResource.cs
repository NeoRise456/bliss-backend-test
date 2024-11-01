
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record AppointmentResource(
    int id,
    int userId,
    int serviceId,
    int companyId, 
    DateTimeOffset? reservationDate,
    string status, 
    DateTime date, 
    string time,
    string requirements
    );