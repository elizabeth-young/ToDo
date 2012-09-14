using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDo.Services
{
    public class ValidationException : Exception
    {
        public string Key { get; set; }
        public string Description { get; set; }

        public ValidationException(string key, string message)
        {
            Key = key;
            Description = message;
        }
    }
}
