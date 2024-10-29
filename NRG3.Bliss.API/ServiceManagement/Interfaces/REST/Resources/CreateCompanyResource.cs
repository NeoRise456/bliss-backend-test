namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

public record CreateCompanyResource(string Name, string Ruc, string Email, string WebsiteUrl, string PhoneNumber, string Description);