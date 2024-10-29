namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record ServiceResource(int Id, CompanyResource Company, CategoryResource Category, string ServiceName, string Description, double Price, double Duration);