﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Core.Models
{
    public class Tbl_Users
    {
        
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name_Surname { get; set; }
    }
}
