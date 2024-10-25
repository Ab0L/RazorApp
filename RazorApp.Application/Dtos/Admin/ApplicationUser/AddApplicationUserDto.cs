using RazorApp.Application.Dtos.Admin.ApplicationUser.Interfaces;
using RazorApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Dtos.Admin.ApplicationUser
{
    public class AddApplicationUserDto : IAddApplicationUserDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string NationalNumber { get; set; }
        public string? Email { get; set; }
        [EnumDataType(typeof(Gender), ErrorMessage = "Please select a valid gender.")]
        public Gender? Gender { get; set; }
        public Domain.Address? Address { get; set; }
    }
}
