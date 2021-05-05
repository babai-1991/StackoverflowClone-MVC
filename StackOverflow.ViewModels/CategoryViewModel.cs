using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}