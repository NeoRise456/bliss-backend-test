using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

public partial class Service
{
    public int Id { get; }
    public int CompanyId { get; private set; }
    public Company Company { get; private set; }
    public int CategoryId { get; private set; }
    public Category Category { get; private set; }
    public string ServiceName { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public double Duration { get; private set; }

    public Service(int companyId, int categoryId, string serviceName, string description, double price, double duration)
    {
        CompanyId = companyId;
        CategoryId = categoryId;
        ServiceName = serviceName;
        Description = description;
        Price = price;
        Duration = duration;
    }
}