﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eag.Jwt.Onion.Core.App.Dto
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; }
    }
}
