﻿using Bee.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bee.Data.Service.Models
{
    public class User : EntityBase
    {
        public string? Name { get; set; }
        public string? EmailAddress { get; set; }
        public string? Password { get; set; }
        public string? EmailConfirmed { get; set; }
        public string? PasswordConfirmed { get; set; }
    }
}
