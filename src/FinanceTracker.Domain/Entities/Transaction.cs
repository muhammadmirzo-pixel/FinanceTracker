using FinanceTracker.Domain.Commons;
using FinanceTracker.Domain.Enums;

namespace FinanceTracker.Domain.Entities;

public class Transaction : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public decimal Amount { get; set; }
    public TypeEnums Type { get; set; } 
    public string Description { get; set; }
}
