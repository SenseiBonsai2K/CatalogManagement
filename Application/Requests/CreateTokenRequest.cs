﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests
{
    public class CreateTokenRequest
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
