using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        //[RegularExpression(@"/^\S+@\S+\.\S+$/")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}