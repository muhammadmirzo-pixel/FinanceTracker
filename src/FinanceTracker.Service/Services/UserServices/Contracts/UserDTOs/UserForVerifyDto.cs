using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.Services.UserServices.Contracts.UserDTOs;
public class UserForVerifyDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public int Code { get; set; }
}
