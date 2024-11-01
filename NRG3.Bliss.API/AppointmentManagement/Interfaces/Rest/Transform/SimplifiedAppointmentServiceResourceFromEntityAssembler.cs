using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;

public static class SimplifiedAppointmentServiceResourceFromEntityAssembler
{
    public static SimplifiedServiceResource ToResourceFromEntity(Service entity)
    {
        return new SimplifiedServiceResource(entity.Id, entity.ServiceName,entity.Price);
    }
}