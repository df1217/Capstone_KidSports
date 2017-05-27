using System.ComponentModel.DataAnnotations;

namespace KidSports.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("^([A-Za-z]){,20}$", ErrorMessage = "Name must be test less than 20 alpha characters") ]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("\\A[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a - z0 - 9](?:[a - z0 - 9 -] *[a - z0 - 9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a - z0 - 9])?\\z",
            ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&])[A-Za-z\\d$@$!%*#?&]{8,}$",
        ErrorMessage = "Password must be at least 8 characters and contain an uppercase, lowercase, digit, and special character")]
      //  [DataType(DataType.Password, ErrorMessage = "Blah")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
