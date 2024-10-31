using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;

public partial class Appointment : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}