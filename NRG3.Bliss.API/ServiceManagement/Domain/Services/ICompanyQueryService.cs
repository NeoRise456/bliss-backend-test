using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICompanyQueryService
{
    Task<IEnumerable<Company>> Handle(GetAllCompaniesQuery query);
}