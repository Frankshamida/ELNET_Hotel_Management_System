using System.ComponentModel.DataAnnotations;

namespace RETRA_HOTEL_SYSTEM_2.ViewModels
{
    public class VerifyEmailViewModel
    {

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
