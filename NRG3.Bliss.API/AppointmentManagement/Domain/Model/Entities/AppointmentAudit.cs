using System.ComponentModel.DataAnnotations.Schema;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Entities;

public partial class Appointment
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}