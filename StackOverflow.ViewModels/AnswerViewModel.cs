using System;
using System.Collections.Generic;

namespace StackOverflow.ViewModels
{
    public class AnswerViewModel
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        public DateTime AnswerDateTime { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public int VotesCount { get; set; }

        public virtual UserViewModel User { get; set; }
        public virtual IList<VoteViewModel> Votes{ get; set; }

        public int CurrentUserGivenVoteType { get; set; }
    }
}