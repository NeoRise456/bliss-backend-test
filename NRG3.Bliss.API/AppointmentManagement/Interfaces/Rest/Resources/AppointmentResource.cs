
using NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record AppointmentResource(
    int id,
    SimplifiedUserResource user,
    SimplifiedServiceResource service,
    SimplifiedCompanyResource company, 
    DateTimeOffset? reservationDate,
    string status, 
    DateTime date, 
    string time,
    string requirements
    );