namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;

public partial class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Dni { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    public User( string firstName, 
        string lastName, 
        string password, 
        string email, 
        string phone, 
        string dni, 
        string address, 
        string city, 
        DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Email = email;
        Phone = phone;
        Dni = dni;
        Address = address;
        City = city;
        BirthDate = birthDate;
    }
    
}