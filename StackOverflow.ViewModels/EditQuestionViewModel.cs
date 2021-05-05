using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class EditQuestionViewModel
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string QuestionName { get; set; }
        [Required]
        public DateTime QuestionDateTime { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}