using RazorApp.Application.Dtos.Admin.City.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Dtos.Admin.City
{
    public class CityDto : ICityDto
    {
        public string Name { get; set; }
    }
}
