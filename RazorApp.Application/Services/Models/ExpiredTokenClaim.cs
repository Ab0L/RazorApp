using System;

namespace RazorApp.Application.Services.Models
{
    public class ExpiredTokenClaim
    {
        public string UserId { get; set; }
        public string RefreshTokenId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
