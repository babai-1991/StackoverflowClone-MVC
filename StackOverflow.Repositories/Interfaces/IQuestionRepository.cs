using System.Collections.Generic;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories.Interfaces
{
    public interface IQuestionRepository
    {
        void InsertQuestion(Question question);
        void UpdateQuestionDetails(Question question);
        /// <summary>
        /// Based on the question id , update the votes of the particular question
        /// </summary>
        /// <param name="questionid"></param>
        /// <param name="voteValue">Similar to stackoverflow downvote -1 , upvote +2 etc.</param>
        void UpdateQuestionVotesCount(int questionid, int voteValue);

        /// <summary>
        /// If new Answer is added then return 1 and if deleted then return -1
        /// </summary>
        /// <param name="questionId"></param>
        /// <param name="returnValue">1 for adding -1 for removing</param>
        void UpdateQuestionAnswersCount(int questionId,int returnValue);

        void UpdateQuestionViewsCount(int questionid);

        void DeleteQuestion(int questionId);
        List<Question> GetQuestions();
        List<Question> GetQuestionsByCategoryId(int categoryId);
        Question GetQuestionByQuestionId(int questionId);

    }
}
