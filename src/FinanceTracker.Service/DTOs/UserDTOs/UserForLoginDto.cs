﻿using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Service.DTOs.UserDTOs;

public class UserForLoginDto
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; } 
}
