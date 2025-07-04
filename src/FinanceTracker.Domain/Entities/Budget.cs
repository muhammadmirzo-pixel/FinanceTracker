using FinanceTracker.Domain.Commons;

namespace FinanceTracker.Domain.Entities;

public class Budget : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public int Period { get; set; }
    public decimal Amount { get; set; }
}
