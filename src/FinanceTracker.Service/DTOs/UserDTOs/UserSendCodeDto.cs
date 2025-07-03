using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.DTOs.UserDTOs;

public class UserSendCodeDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
