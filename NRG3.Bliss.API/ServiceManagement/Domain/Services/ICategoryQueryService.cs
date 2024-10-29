using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICategoryQueryService
{
    Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query);
    Task<Category?> Handle(GetCategoryByIdQuery query);
}