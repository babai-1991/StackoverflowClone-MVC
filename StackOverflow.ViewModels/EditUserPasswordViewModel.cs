using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class EditUserPasswordViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}