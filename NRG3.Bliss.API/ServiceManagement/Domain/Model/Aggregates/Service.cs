using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

public class Service
{
    public int Id { get; private set; }
    public string CategoryId { get; private set; }
    public string CompanyId { get; private set; }
    public string ServiceName { get; private set; }
    public string Description { get; private set; }
    public int Price { get; private set; }
    public int Duration { get; private set; }
    
    protected Service()
    {
        this.CategoryId = string.Empty;
        this.CompanyId = string.Empty;
        this.ServiceName = string.Empty;
        this.Description = string.Empty;
        this.Price = 0;
        this.Duration = 0;
    }
    
    public Service(CreateServiceCommand command)
    {
        this.CategoryId = command.CategoryId;
        this.CompanyId = command.CompanyId;
        this.ServiceName = command.ServiceName;
        this.Description = command.Description;
        this.Price = command.Price;
        this.Duration = command.Duration;
    }
    
}