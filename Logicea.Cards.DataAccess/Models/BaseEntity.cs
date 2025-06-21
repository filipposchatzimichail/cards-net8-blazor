namespace Logicea.Cards.DataAccess.Models;

public class BaseEntity
{
    public Guid Id { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public required string UpdatedBy { get; set; }
    public DateTime UpdatedDate { get; set; } 
}
