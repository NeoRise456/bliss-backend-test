namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

public record CreateServiceCommand(string CategoryId, string CompanyId, string ServiceName, string Description, int Price, int Duration);