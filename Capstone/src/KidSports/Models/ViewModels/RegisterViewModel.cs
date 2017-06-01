using System.ComponentModel.DataAnnotations;

namespace KidSports.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
       
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name must be less than 20 characters")]
        [RegularExpression("^([A-Z]{1}[a-zA-Z ]*$)", ErrorMessage = "Name must be capitalized and not contain any digits or special characters")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
      
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[$@$!%*#?&.])[A-Za-z\\d$@$!%*#?&.]{8,}$",
        ErrorMessage = "Password must be at least 8 characters and contain an uppercase, lowercase, digit, and special character")]
     
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
