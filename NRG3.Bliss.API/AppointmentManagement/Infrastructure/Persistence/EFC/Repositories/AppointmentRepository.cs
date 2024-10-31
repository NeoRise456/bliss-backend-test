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
    
    
}