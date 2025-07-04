using FinanceTracker.Domain.Commons;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Entities;

public class Category : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TypeEnums Status { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
}
