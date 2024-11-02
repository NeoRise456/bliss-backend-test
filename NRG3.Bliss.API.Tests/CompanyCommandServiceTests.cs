using Moq;
using NRG3.Bliss.API.ServiceManagement.Application.Internal.CommandServices;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using Xunit;
// integrations tests are used to test the interaction between different parts of the system, in this case the interaction between the CompanyCommandService class and the CompanyRepository class
namespace NRG3.Bliss.API.Tests
{
    public class CompanyCommandServiceTests
    {
        private readonly Mock<ICompanyRepository> _companyRepositoryMock;// se esta creando un mock de la interfaz ICompanyRepository para simular el comportamiento de la base de datos 
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;// se esta creando un mock de la interfaz IUnitOfWork para simular el comportamiento de la base de datos que se encarga de guardar los cambios en la base de datos
        private readonly  CompanyCommandService _companyCommandService;// se esta creando una instancia de la clase CompanyCommandService que se encarga de manejar los comandos de la empresa 
        
        public CompanyCommandServiceTests()// se esta creando un constructor que inicializa las variables de la clase CompanyCommandServiceTests
        {
            _companyRepositoryMock = new Mock<ICompanyRepository>();// se inicializa la variable _companyRepositoryMock con un nuevo mock de la interfaz ICompanyRepository
            _unitOfWorkMock = new Mock<IUnitOfWork>();// se inicializa la variable _unitOfWorkMock con un nuevo mock de la interfaz IUnitOfWork
            _companyCommandService = new CompanyCommandService(_companyRepositoryMock.Object, _unitOfWorkMock.Object);// se inicializa la variable _companyCommandService con una nueva instancia de la clase CompanyCommandService que recibe como parametros el mock de la interfaz ICompanyRepository y el mock de la interfaz IUnitOfWork
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenCompanyNameExists()
        {
            // Arrange
            // A new instance of the CreateCompanyCommand class is being created with the parameters of the existing company
            //TS001
            // [Given] that a new company is being created
            var command = new CreateCompanyCommand(
                "ExistingCompany",
                "123456789",
                "compan1@gmail.com",
                "www.company1.com",
                "123456789",
                "Company1Description"
            );//[AND] a company with the same name as the company being created already exists in the database
            _companyRepositoryMock.Setup(repo => repo.FindCompaniesByCompanyName(command.Name))
                .ReturnsAsync(new List<Company> { new Company { Name = "ExistingCompany" } });//[WHEN] the new company is added

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => _companyCommandService.Handle(command));// se esta verificando que al llamar al metodo Handle de la clase CompanyCommandService con el comando de la empresa existente se lance una excepcion de tipo InvalidOperationException
            Assert.Equal("The company name already exists.", exception.Message);//[THEN] an exception is sent that says "The company name already exists.".
        }

        [Fact]// se esta creando un nuevo test llamado Handle_ShouldCreateCompany_WhenCompanyNameDoesNotExist
        public async Task Handle_ShouldCreateCompany_WhenCompanyNameDoesNotExist()
        {
            // Arrange
            var command = new CreateCompanyCommand(
                "NewCompany",
                "123456789",
                "compan1@gmail.com",
                "www.company1.com",
                "123456789",
                "Company1Description"
            );// se esta creando una nueva instancia de la clase CreateCompanyCommand con los parametros de la empresa nueva 
            _companyRepositoryMock.Setup(repo => repo.FindCompaniesByCompanyName(command.Name))
                .ReturnsAsync(new List<Company>());// se esta configurando el mock de la interfaz ICompanyRepository para que retorne una lista vacia de empresas
            _companyRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Company>())).Returns(Task.CompletedTask);// se esta configurando el mock de la interfaz ICompanyRepository para que retorne una tarea completada cuando se llame al metodo AddAsync con cualquier empresa como parametro 
            _unitOfWorkMock.Setup(uow => uow.CompleteAsync()).Returns(Task.CompletedTask);// se esta configurando el mock de la interfaz IUnitOfWork para que retorne una tarea completada cuando se llame al metodo CompleteAsync

            // Act
            var result = await _companyCommandService.Handle(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(command.Name, result.Name);
            _companyRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Company>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.CompleteAsync(), Times.Once);
        }
    
    }
}

