using System.ComponentModel.DataAnnotations;

namespace ClipShare.ViewModels.Account
{
    public class Register_vm
    {
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(120, MinimumLength = 5, ErrorMessage = "Full name must be at least {2}, and maximum {1} characters.")]
        [RegularExpression("^[a-zA-Z -]*$", ErrorMessage = "Full name must contain only a-z A-Z - characters")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Username is required")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Username must be at least {2}, and maximum {1} characters")]
        [RegularExpression("^[a-zA-Z0-9_.-]*$", ErrorMessage = "Username must contain only a-z A-Z 0-9 characters")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-zA-Z])(?=.*[^a-zA-Z0-9]).{6,15}$", ErrorMessage = "Password must contain at least one letter, one number, one special character, and be between 6-15 characters in length.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
