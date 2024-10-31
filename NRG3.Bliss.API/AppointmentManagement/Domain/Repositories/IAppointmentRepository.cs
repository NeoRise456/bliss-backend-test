using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

public interface IAppointmentRepository : IBaseRepository<Appointment>
{
    Task<Appointment?> FindByIdAsync(int id);
    Task<IEnumerable<Appointment>> FindByUserIdAsync(int userId);
}