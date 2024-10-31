
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record AppointmentResource(
    int id,
    UserResource user,
    ServiceResource service,
    CompanyResource company, 
    DateTimeOffset? reservationDate,
    string status, 
    DateTime date, 
    string time,
    string requirements
    );