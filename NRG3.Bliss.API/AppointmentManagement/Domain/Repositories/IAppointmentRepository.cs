using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> FindAppointmentsByUserIdAsync(int userId);
}