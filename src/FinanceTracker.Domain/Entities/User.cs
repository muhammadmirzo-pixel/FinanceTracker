using FinanceTracker.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.Domain.Entities;

[Table("users", Schema ="auth")]
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
