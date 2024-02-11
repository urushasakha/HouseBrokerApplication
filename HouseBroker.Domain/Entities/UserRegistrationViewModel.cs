using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseBroker.Domain.Entities
{
    public class UserRegistrationViewModel
    {
        
        [Required]
        public string FullName { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
