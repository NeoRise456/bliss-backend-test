


using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.Tests.ServiceTest
{
    public class ServiceCommandServiceTests
    {
       private readonly Mock<IServiceRepository> _serviceRepositoryMock;
       private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
       private readonly Mock<ICompanyRepository> _companyRepositoryMock;
       private readonly Mock<IUnitOfWork> _unitOfWorkMock;
       private readonly ServiceCommandService _serviceCommandService;

        public ServiceCommandServiceTests()
        {
            _serviceRepositoryMock = new Mock<IServiceRepository>();
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _companyRepositoryMock = new Mock<ICompanyRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _serviceCommandService = new ServiceCommandService(
                _serviceRepositoryMock.Object,
                _categoryRepositoryMock.Object, 
                _companyRepositoryMock.Object,
                _unitOfWorkMock.Object);
        }
        // [Scenario]: Attempting to create a service with a duplicate name
        [Fact]
        public async Task Handle_WhenServiceNameIsNotUnique()
        {
            // [Given]: that a new service is to be created
            var commad = new CreateServiceCommand(
                1,
                1,
                "DuplicateServiceName",
                "DescriptionService",
                100,
                30
                );
            // [When]: service data is passed with an existing name for the company and category.
            _serviceRepositoryMock.Setup(repo =>
                repo.ServiceNameExistsForCompanyAndCategoryAsync(commad.CompanyId, commad.CategoryId, commad.ServiceName)).ReturnsAsync(true);
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _serviceCommandService.Handle(commad));
            // [Then]: An InvalidOperationException is thrown with the message "The service name already exists for the company and category."
            Assert.Equal("The service name already exists for the company and category.", exception.Message);
        }

        


    }
}

