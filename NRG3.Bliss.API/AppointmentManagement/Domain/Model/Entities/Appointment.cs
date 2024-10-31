using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;

public partial class Appointment
{
    public int Id { get; set; }

    public int UserId { get; set; }
    
    public int ServiceId { get; set; }
    
    public int CompanyId { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public string Status { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Time { get; set; }
    
    public Appointment()
    {
        Status = string.Empty;
        Time = string.Empty;
    }

    public Appointment(int userId, int serviceId, int companyId, DateTime reservationDate, string status, DateTime date, string time)
    {
        UserId = userId;
        ServiceId = serviceId;
        CompanyId = companyId;
        ReservationDate = reservationDate;
        Status = status;
        Date = date;
        Time = time;
    }
    
    public Appointment(CreateAppointmentCommand command)
    {
        UserId = command.UserId;
        ServiceId = command.ServiceId;
        CompanyId = command.CompanyId;
        ReservationDate = command.ReservationDate;
        Status = command.Status;
        Date = command.Date;
        Time = command.Time;
    }
}