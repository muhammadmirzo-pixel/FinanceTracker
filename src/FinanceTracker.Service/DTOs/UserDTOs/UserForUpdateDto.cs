using FinanceTracker.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.DTOs.UserDTOs;

public class UserForUpdateDto
{
    [Required]
    [StringLength(20)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(20)]
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [LocalPhoneAttribute]
    public string PhoneNumber { get; set; }
}
