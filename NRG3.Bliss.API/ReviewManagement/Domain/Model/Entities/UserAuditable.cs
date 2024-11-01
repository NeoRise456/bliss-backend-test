using System.ComponentModel.DataAnnotations.Schema;

namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Entity;

public class UserAuditable
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}