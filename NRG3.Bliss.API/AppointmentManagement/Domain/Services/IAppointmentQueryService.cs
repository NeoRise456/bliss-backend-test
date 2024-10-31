using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Services;

public interface IAppointmentQueryService
{
    Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsByUserIdQuery query);
    Task<Appointment?> Handle(GetAppointmentByIdQuery query);
    
}