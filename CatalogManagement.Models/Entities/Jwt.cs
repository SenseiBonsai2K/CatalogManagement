﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManagement.Models.Entities
{
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
