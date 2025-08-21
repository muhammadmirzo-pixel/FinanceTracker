using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.Services.UserServices.Contracts.UserDTOs;

public class UserSendCodeDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}
