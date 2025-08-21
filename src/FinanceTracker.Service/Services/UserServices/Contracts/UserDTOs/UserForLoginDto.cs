using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.Services.UserServices.Contracts.UserDTOs;

public class UserForLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; } 
}
