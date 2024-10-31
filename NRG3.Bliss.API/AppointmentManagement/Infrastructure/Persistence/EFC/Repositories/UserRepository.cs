using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.AppointmentManagement.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    
}