﻿using System.Collections.Generic;

namespace RazorApp.Domain.Common
{
    public class State : BaseDomainEntity
    {
        public string Name { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}