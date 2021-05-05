using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories.Interfaces
{
    public interface IAnswersRepository
    {
        void InsertAnswer(Answer answer);
        void UpdateAnswer(Answer answer);
        void UpdateAnswerVotesCount(int answerId, int userId, int voteValue);
        void DeleteAnswer(int answerid);
        List<Answer> GetAnswersByQuestionId(int questionid);
        Answer GetAnswer(int answerid);

    }

}
