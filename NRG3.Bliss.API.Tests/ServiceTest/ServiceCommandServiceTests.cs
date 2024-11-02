


using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
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

        


    }
}

