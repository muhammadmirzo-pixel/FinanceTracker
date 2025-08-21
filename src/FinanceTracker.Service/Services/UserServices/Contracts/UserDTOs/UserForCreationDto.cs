using FinanceTracker.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.Services.UserServices.Contracts.UserDTOs;

public class UserForCreationDto
{
    private const int MinPassLenth = 8;
    private const int MaxPassLenth = 20;

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
    [LocalPhone]
    public string PhoneNumber { get; set; }

    [Required]
    [MinLength(MinPassLenth)]
    [MaxLength(MaxPassLenth)]
    public string PasswordHash { get; set; }
}
