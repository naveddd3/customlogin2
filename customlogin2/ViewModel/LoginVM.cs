using System.ComponentModel.DataAnnotations;

namespace customlogin2.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password Is Required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "RememberMe")]
        public bool RememberMe { get; set; }
    }
}
