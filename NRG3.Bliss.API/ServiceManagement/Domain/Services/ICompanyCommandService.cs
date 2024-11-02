using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Services;

public interface ICompanyCommandService
{
    Task<Company?> Handle(CreateCompanyCommand command);
}