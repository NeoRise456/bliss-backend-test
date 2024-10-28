using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

public partial class Service
{
    public int Id { get; private set; }
    public string CategoryId { get; private set; }
    public string CompanyId { get; private set; }
    public string ServiceName { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public double Duration { get; private set; }

    public Service()
    {
        this.CategoryId = string.Empty;
        this.CompanyId = string.Empty;
        this.ServiceName = string.Empty;
        this.Description = string.Empty;
        this.Price = 0;
        this.Duration = 0;
    }

    public Service(string categoryId, string companyId, string serviceName, string description, double price, double duration)
    {
        this.CategoryId = categoryId;
        this.CompanyId = companyId;
        this.ServiceName = serviceName;
        this.Description = description;
        this.Price = price;
        this.Duration = duration;
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