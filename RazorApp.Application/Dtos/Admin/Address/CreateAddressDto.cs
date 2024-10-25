using RazorApp.Application.Dtos.Admin.Address.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorApp.Application.Dtos.Admin.Address
{
    public class CreateAddressDto : IAddressDto
    {
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public string ApplicationUserId { get; set; }
        public string AddressTitle { get; set; }
        public string PostalCode { get; set; }
        public string UserAddress { get; set; }
    }
}
