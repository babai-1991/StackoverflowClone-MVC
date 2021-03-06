using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class EditAnswerViewModel
    {
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public int AnswerText { get; set; }
        [Required]
        public DateTime AnswerDateTime { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int VotesCount { get; set; }
        [Required]
        public virtual QuestionViewModel Question { get; set; }

    }
}