﻿using RazorApp.Domain.Common;
using System.Net.Mail;
using System;

namespace RazorApp.Domain.Auth
{
    public class LoginHelperSession : BaseDomainEntity
    {
        public string NationalNumber { get; set; }  // National Number associated with the session
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime ExpireAt { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
    }
}