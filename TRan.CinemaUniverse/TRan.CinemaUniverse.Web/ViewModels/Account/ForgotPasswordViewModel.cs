using System.ComponentModel.DataAnnotations;

namespace TRan.CinemaUniverse.Web.ViewModels.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}