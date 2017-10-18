using System.ComponentModel.DataAnnotations;

namespace TRan.CinemaUniverse.Web.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}