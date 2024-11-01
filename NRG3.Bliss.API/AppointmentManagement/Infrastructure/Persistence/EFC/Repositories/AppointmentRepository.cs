using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Infrastructure.Persistence.EFC.Repositories;

public class AppointmentRepository(AppDbContext context): BaseRepository<Appointment>(context), IAppointmentRepository
{
    public async Task<IEnumerable<Appointment>> FindAppointmentsByUserIdAsync(int userId) => 
        await Context.Set<Appointment>()
            .Include(a => a.User)
            .Include(a => a.Company)
            .Include(a=>a.Service)
            .Where(a => a.UserId == userId).ToListAsync();

    public async Task<Appointment?> FindByServiceIdAndTimeAsync(int serviceId, DateTime reservationDate, string reservationStartTime)
        => await Context.Set<Appointment>()
            .Include(a => a.User)
            .Include(a => a.Company)
            .Include(a=>a.Service)
            .FirstOrDefaultAsync(a => a.ServiceId == serviceId && a.ReservationDate == reservationDate && a.ReservationStartTime == reservationStartTime);

    public async Task<Appointment?> FindByUserIdAndTimeAsync(int userId, DateTime reservationDate, string reservationStartTime)
    => await Context.Set<Appointment>()
        .Include(a => a.User)
        .Include(a => a.Company)
        .Include(a=>a.Service)
        .FirstOrDefaultAsync(a => a.UserId == userId && a.ReservationDate == reservationDate && a.ReservationStartTime == reservationStartTime);

    public async Task<Appointment?> FindAppointmentByIdAsync(int appointmentId)
    => await Context.Set<Appointment>()
        .Include(a => a.User)
        .Include(a => a.Company)
        .Include(a=>a.Service)
        .FirstOrDefaultAsync(a => a.Id == appointmentId);
}