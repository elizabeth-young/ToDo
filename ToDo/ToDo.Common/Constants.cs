using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Common
{
    public static class Constants
    {
        public static class Regexes
        {
            public const string EmailRegex = "^[A-Za-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9-]+)*\\.([a-z]{2,4})$";
            public const string UsernameRegex = "^[a-zA-Z0-9]+$";
            public const string PasswordRegex = "^(?=.*\\d).{8,32}$";
        }
    }
}
