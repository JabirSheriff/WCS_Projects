﻿namespace ClinicAPI.Models.DTOs
{
    public class LoginResponseDto
    {
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
