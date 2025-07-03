using FinanceTracker.Domain.Commons;

namespace FinanceTracker.Domain.Entities;

public class Budget : Auditable
{
    public int UserId { get; set; }
    public User User { get; set; }
    public List<Category> Category { get; set; }
    public int CategoryId { get; set; }
    public int Period { get; set; }
    public decimal Amount { get; set; }
}
