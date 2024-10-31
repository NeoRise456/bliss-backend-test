namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record ServiceResource(int Id, ServiceCompanyResource Company, ServiceCategoryResource Category, string ServiceName, string Description, double Price, double Duration);