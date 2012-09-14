using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using ToDo.Common;

namespace ToDo.Services
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(Constants.Regexes.UsernameRegex, ErrorMessage = "Only letters and numbers")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(Constants.Regexes.PasswordRegex, ErrorMessage = "At least one number")]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(Constants.Regexes.EmailRegex, ErrorMessage = "Not a valid email")]
        public string Email { get; set; }
    }
}
