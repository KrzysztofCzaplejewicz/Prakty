using System.ComponentModel.DataAnnotations;

namespace GameHub.ViewModels
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}