using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
    public class AccountLoginViewModel
    {
        private string _password;
        [StringLength(40, ErrorMessage = "Username has maximum 40 chars.")]
        [Required(ErrorMessage = "Username field is required.")]
        [MinLength(5, ErrorMessage = "Username must have at least 5 letters.")]
        public string Username { get; set; }

        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = " must be alphanumeric.")]
        [StringLength(70, ErrorMessage = "Password has maximum 70 chars.")]
        [Required(ErrorMessage = "Password field is required.")]
        [MinLength(5, ErrorMessage = "Password must have at least 5 letters.")]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = Modules.Cryptography.Encrypt(value, "password");
            }
        }
    }
}
