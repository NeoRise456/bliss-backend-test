using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.ReviewManagement.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository for the Review entity
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Review>> FindReviewsByUserIdAsync(int userId) =>
        await Context.Set<Review>()
            .Include(r => r.UserR)
            .Include(r => r.Appointment)
            .Where(r => r.UserId == userId).ToListAsync();

    /// <inheritdoc />
    public async Task<IEnumerable<Review>> FindReviewsByAppointmentIdAsync(int appointmentId) =>
        await Context.Set<Review>()
            .Include(r => r.UserR)
            .Include(r => r.Appointment)
            .Where(r => r.AppointmentId == appointmentId).ToListAsync();

    /// <inheritdoc />
    public async Task<IEnumerable<Review>> FindReviewsByCompanyIdAsync(int companyId) =>
        await Context.Set<Review>()
            .Include(r => r.UserR)
            .Include(r => r.Appointment)
            .Where(r => r.Appointment.CompanyId == companyId).ToListAsync();

    /// <inheritdoc />
    public async Task<Review?> FindReviewByIdAsync(int reviewId) =>
        await Context.Set<Review>()
            .Include(r => r.UserR)
            .Include(r => r.Appointment)
            .FirstOrDefaultAsync(r => r.Id == reviewId);

    /// <inheritdoc />
    public async Task<bool> CanCreateReviewForAppointmentAsync(int appointmentId) =>
        !await Context.Set<Review>().AnyAsync(r => r.AppointmentId == appointmentId);
}