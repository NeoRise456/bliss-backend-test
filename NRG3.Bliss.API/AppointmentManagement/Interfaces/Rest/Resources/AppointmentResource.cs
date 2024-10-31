using Org.BouncyCastle.Asn1.Cms;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record AppointmentResource(
    int id,
    int userId,
    int serviceId,
    int companyId, 
    DateTime reservationDate,
    string status, 
    DateTime date, 
    string time
    );