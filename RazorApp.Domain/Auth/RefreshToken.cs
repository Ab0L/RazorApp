using RazorApp.Domain.Common;
using System;

namespace RazorApp.Domain.Auth
{
    public class RefreshToken : BaseDomainEntity
    {
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
