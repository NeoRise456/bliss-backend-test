namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

public record UserResource(
    int Id,
    string FirstName,
    string LastName,
    string Password,
    string Email,
    string Phone,
    string Dni,
    string Address,
    string City,
    DateTime BirthDate
    );