using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Infrastructure.Persistence.EFC.Repositories;

public class ServiceRepository(AppDbContext context) : BaseRepository<Service>(context), IServiceRepository
{
    public async Task<IEnumerable<Service>> FindServicesByCompanyIdAsync(int companyId) =>
        await Context.Set<Service>()
            .Include(s => s.Company)
            .Include(s =>s.Category)
            .Where(s => s.CompanyId == companyId)
            .ToListAsync();

    public async Task<IEnumerable<Service>> GetAllServices() =>
        await Context.Set<Service>()
            .Include(s => s.Company)
            .Include(s => s.Category)
            .ToListAsync();

    public async Task<Service?> GetServiceById(int serviceId)
    {
        return await Context.Set<Service>()
            .Include(s => s.Company)
            .Include(s => s.Category)
            .FirstOrDefaultAsync(s => s.Id == serviceId);
    }
        
}