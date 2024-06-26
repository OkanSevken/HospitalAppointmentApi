﻿using HospitalApi.Domain.Cammon;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalApi.Domain.Entities
{
    public class User : IdentityUser<int>,IEntityBase
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? UsernameSurname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
