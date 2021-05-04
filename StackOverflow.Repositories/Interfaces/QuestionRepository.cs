using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;

namespace StackOverflow.Repositories.Interfaces
{
    public class QuestionRepository:IQuestionRepository
    {
        private readonly StackOverflowDbContext db;

        public QuestionRepository()
        {
            db = new StackOverflowDbContext();
        }
        public void InsertQuestion(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
        }

        public void UpdateQuestionDetails(Question question)
        {
            Question updatingQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == question.QuestionID);
            if (updatingQuestion!=null)
            {
                updatingQuestion.QuestionName = question.QuestionName;
                updatingQuestion.QuestionDateAndTime = question.QuestionDateAndTime;
                updatingQuestion.CategoryID = question.CategoryID;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionVotesCount(int questionid, int voteValue)
        {
            Question updatingQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == questionid);
            if (updatingQuestion != null)
            {
                updatingQuestion.VotesCount += voteValue;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionAnswersCount(int questionId, int returnValue)
        {
            Question updatingQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == questionId);
            if (updatingQuestion != null)
            {
                updatingQuestion.AnswersCount += returnValue;
                db.SaveChanges();
            }
        }

        public void UpdateQuestionViewsCount(int questionid)
        {
            Question updatingQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == questionid);
            if (updatingQuestion != null)
            {
                updatingQuestion.ViewsCount += 1;
                db.SaveChanges();
            }
        }

        public void DeleteQuestion(int questionId)
        {
            Question deletingQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == questionId);
            if (deletingQuestion != null)
            {
                db.Questions.Remove(deletingQuestion);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions()
        {
            return db.Questions.OrderByDescending(q => q.QuestionDateAndTime).ToList();
        }

        public List<Question> GetQuestionsByCategoryId(int categoryId)
        {
            List<Question> questions = db.Questions.Where(q => q.CategoryID == categoryId).ToList();
            return questions;
        }

        public Question GetQuestionByQuestionId(int questionId)
        {
            Question fetchQuestion = db.Questions.FirstOrDefault(q => q.QuestionID == questionId);
            return fetchQuestion;
        }
    }
}