using System.ComponentModel.DataAnnotations;

namespace RETRA_HOTEL_SYSTEM_2.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Message is required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password id required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
