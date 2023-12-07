using System.ComponentModel.DataAnnotations;

namespace customlogin2.ViewModel
{
    public class RegistrationVM
    {
        [Required]
        public string  Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string?  Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password",ErrorMessage ="Password does not match")]
        public string? ConfirmPassword { get; set; }
        public string? Address { get; set; }
    }
}
