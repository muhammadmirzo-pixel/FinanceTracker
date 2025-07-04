using FinanceTracker.Domain.Commons;

namespace FinanceTracker.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Email { get; set; } 
    public string PhoneNumber { get; set; } 
    public string PasswordHash { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public DateTime? LastPasswordChangeAt { get; set; }
}
