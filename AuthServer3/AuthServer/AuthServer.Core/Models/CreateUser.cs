using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.Models
{
    public class CreateUser
    {
        public string Name_Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
