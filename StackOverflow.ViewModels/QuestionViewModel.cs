using System;
using System.Collections.Generic;

namespace StackOverflow.ViewModels
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionName { get; set; }
        public DateTime QuestionDateAndTime { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int VotesCount { get; set; }
        public int AnswersCount { get; set; }
        public int ViewsCount { get; set; }

        //Details information about user, who ask this question
        public UserViewModel User { get; set; }

        //category details
        public CategoryViewModel Category { get; set; }

        //May have one no or more answer
        public virtual IList<AnswerViewModel> Answers{ get; set; }

    }
}