using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Account
{
    public class AccountCreateViewModel
    {
        private string _password;
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = " must be alphanumeric.")]
        [Required(ErrorMessage = "First name field is required.")]
        [StringLength(40,ErrorMessage = "First name has maximum 40 chars.")]
        [MinLength(2,ErrorMessage ="First name must have at least 2 letters.")]
        public string FirstName { get; set; }


        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = " must be alphanumeric.")]
        [Required(ErrorMessage = "Last name field is required.")]
        [StringLength(40, ErrorMessage = "Last name has maximum 40 chars.")]
        [MinLength(2, ErrorMessage = "Last name must have at least 2 letters.")]
        public string LastName { get; set; }


        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = " must be alphanumeric.")]
        [StringLength(40, ErrorMessage = "Username has maximum 40 chars.")]
        [Required(ErrorMessage = "Username field is required.")]
        [MinLength(5, ErrorMessage = "Usernamemust have at least 5 letters.")]
        public string UserName { get; set; }


        [StringLength(100, ErrorMessage = "Address has maximum 100 chars.")]
        [Required(ErrorMessage = "Adress field is required.")]
        [MinLength(5, ErrorMessage = "Address must have at least 5 letters.")]
        public string Adress { get; set; }


        [StringLength(70, ErrorMessage = "Email has maximum 70 chars.")]
        [EmailAddress(ErrorMessage ="Email adress not valid.")]
        [Required(ErrorMessage = "Email field is required.")]
        [MinLength(6, ErrorMessage = "Email must have at least 6 letters")]
        public string Email { get; set; }


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
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number must contain only NUMBERS!")]
        [StringLength(12, ErrorMessage = "Phone number has maximum 12 chars")]
        [Required(ErrorMessage = "Phone number field is required")]
        [MinLength(8, ErrorMessage = "Phone number must have at least 8 letters.")]
        public string PhoneNumber { get; set; }
        public string ImageLink { get; set; }
    }
}
