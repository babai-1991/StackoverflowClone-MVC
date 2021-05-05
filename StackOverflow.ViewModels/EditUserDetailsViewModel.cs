using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class EditUserDetailsViewModel
    {
        [Required]
        [RegularExpression("/^[a-zA-Z]*$/")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"/^\S+@\S+\.\S+$/")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$")]
        public string Mobile { get; set; }
    }
}