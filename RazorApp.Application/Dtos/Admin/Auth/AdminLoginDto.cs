using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Dtos.Admin.Auth
{
    public class AdminLoginDto
    {
        public string UserName { get; set; }
        public string PassswordHash { get; set; }
    }
}
