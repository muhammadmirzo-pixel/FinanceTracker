﻿namespace FinanceTracker.Service.DTOs.AuthDTOs;

public class VerificationDto
{
    public int Code { get; set; }
    public int Attempt { get; set; }
    public DateTime CreatedAt { get; set; }
}
