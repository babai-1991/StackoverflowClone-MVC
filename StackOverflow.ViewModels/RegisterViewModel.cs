using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [RegularExpression("/^[a-zA-Z]*$/")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"/^\S+@\S+\.\S+$/")]
        public string  Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public string Mobile { get; set; }
    }
}
