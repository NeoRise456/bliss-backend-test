using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Services;

public interface IAppointmentCommandService
{
    Task<Appointment> Handle(CreateAppointmentCommand command);
}