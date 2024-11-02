using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.ServiceManagement.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;

public class ServiceCommandService(
    IServiceRepository serviceRepository,
    ICategoryRepository categoryRepository,
    ICompanyRepository companyRepository,
    IUnitOfWork unitOfWork)
    :IServiceCommandService
{
    public async Task<Service?> Handle(CreateServiceCommand command)
    {
        if (await serviceRepository.ServiceNameExistsForCompanyAndCategoryAsync(command.CompanyId, command.CategoryId,
                command.ServiceName))
        {
            throw new InvalidOperationException("The service name already exists for the company and category.");
        }
        var service = new Service(command.CompanyId, command.CategoryId, command.ServiceName, command.Description, command.Price, command.Duration);
        await serviceRepository.AddAsync(service);
        await unitOfWork.CompleteAsync();
        var category = await categoryRepository.FindByIdAsync(command.CategoryId);
        var company = await companyRepository.FindByIdAsync(command.CompanyId);
        service.Category = category;
        service.Company = company;
        return service;
    }
}