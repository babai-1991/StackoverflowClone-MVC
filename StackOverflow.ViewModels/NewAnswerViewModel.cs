using System;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.ViewModels
{
    public class NewAnswerViewModel
    {
        [Required]
        public string AnswerText { get; set; }
        [Required]
        public DateTime AnswerDateTime { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VotesCount { get; set; }
    }
}