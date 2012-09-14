using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Services
{
    public class AuthenticationModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Admin { get; set; }
    }
}
