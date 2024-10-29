namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record CreateServiceResource(int CompanyId,int CategoryId, string ServiceName, string Description, double Price, double Duration);