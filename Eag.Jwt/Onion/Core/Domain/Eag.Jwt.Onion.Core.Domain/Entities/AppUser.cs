﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.Domain.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int AppRoleId { get; set; }
        public AppRole? AppRole { get; set; }
    }
}
