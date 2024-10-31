using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Queries;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.AppointmentManagement.Domain.Services;

namespace NRG3.Bliss.API.AppointmentManagement.Application.Internal.QueryServices;

public class AppointmentQueryService(IAppointmentRepository appointmentRepository) : IAppointmentQueryService
{
    public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsByUserIdQuery query)
    {
        return await appointmentRepository.FindAppointmentsByUserIdAsync(query.UserId);
    }

    public async Task<Appointment?> Handle(GetAppointmentByIdQuery query)
    {
        return await appointmentRepository.FindAppointmentByIdAsync(query.Id);
    }
}