using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflow.DomainModels
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerID { get; set; }

        public string AnswerText { get; set; }
        public DateTime AnswerDateAndTime { get; set; }

        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User User{ get; set; }

        public int QuestionID { get; set; }
        [ForeignKey("QuestionID")]
        public virtual Question Question { get; set; }

        public int VotesCount { get; set; }

        public virtual IList<Vote> Votes{ get; set; }
    }
}