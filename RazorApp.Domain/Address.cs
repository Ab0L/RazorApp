using RazorApp.Domain.Common;
using System;

namespace RazorApp.Domain
{
    public class Address : BaseDomainEntity
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string AddressTitle { get; set; }
        public string PostalCode { get; set; }
        public string UserAddress { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public Guid StateId { get; set; }
        public State State { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
