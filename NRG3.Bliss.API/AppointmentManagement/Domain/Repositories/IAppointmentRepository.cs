using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<IEnumerable<Appointment>> FindAppointmentsByUserIdAsync(int userId);
    Task<Appointment?> FindByServiceIdAndTimeAsync(int serviceId, DateTime reservationDate, string reservationStartTime);
    Task<Appointment?> FindByUserIdAndTimeAsync(int userId, DateTime reservationDate, string reservationStartTime);
    Task<Appointment?> FindAppointmentByIdAsync(int appointmentId);
    
}