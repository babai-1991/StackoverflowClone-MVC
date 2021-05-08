using System.Collections.Generic;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer.Interfaces
{
    interface IQuestionService
    {
        void InsertQuestion(NewQuestionViewModel newQuestionViewModel);
        void UpdateQuestionDetails(EditQuestionViewModel editQuestionViewModel);
        void UpdateQuestionVotesCount(int questionId, int value);
        void UpdateQuestionAnswerCount(int questionid,int value);
        void UpdateQuestionViewCount(int questionId);
        void DeleteQuestion(int questionId);
        List<QuestionViewModel> GetQuestions();
        //after displaying the question ,user should view wheather he upvoted downvoted that question . So pass userId
        QuestionViewModel GetQuestionByQuestionId(int questionid,int userId);


    }
}
