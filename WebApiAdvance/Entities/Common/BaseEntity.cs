using System.ComponentModel.DataAnnotations;

namespace WebApiAdvance.Entities.Common;

public class BaseEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


}
