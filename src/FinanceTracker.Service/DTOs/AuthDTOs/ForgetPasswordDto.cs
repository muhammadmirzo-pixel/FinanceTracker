﻿namespace FinanceTracker.Service.DTOs.AuthDTOs;

public class ForgetPasswordDto
{
    public string Email { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
