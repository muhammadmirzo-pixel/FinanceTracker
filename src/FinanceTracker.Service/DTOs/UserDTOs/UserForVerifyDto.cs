using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.DTOs.UserDTOs;
public class UserForVerifyDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public int Code { get; set; }
}
