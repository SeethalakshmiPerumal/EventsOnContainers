﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string Address { get; set; }
    }
}
