﻿using System.ComponentModel.DataAnnotations;

namespace Meter.Requests.Auth;

public class LoginRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}