using System.Collections.Generic;
using System.Linq;
using StackOverflow.DomainModels;
using StackOverflow.Repositories.Interfaces;

namespace StackOverflow.Repositories
{
    public class AnswersRepository : IAnswersRepository
    {
        private readonly StackOverflowDbContext db;
        private readonly IQuestionRepository questionRepository;
        private readonly IVotesRepository votesRepository;

        public AnswersRepository()
        {
            db = new StackOverflowDbContext();
            questionRepository = new QuestionRepository();
            votesRepository = new VotesRepository();
        }
        public void InsertAnswer(Answer answer)
        {
            db.Answers.Add(answer);
            db.SaveChanges();
            questionRepository.UpdateQuestionAnswersCount(answer.QuestionID, 1);
        }

        public void UpdateAnswer(Answer answer)
        {
            Answer updateAnswer = db.Answers.FirstOrDefault(a => a.AnswerID == answer.AnswerID);
            if (updateAnswer != null)
            {
                updateAnswer.AnswerText = answer.AnswerText;
                db.SaveChanges();
            }
        }

        public void UpdateAnswerVotesCount(int answerId, int userId, int voteValue)
        {
            Answer updateAnswer = db.Answers.FirstOrDefault(a => a.AnswerID == answerId);
            if (updateAnswer != null)
            {
                updateAnswer.VotesCount += voteValue;
                db.SaveChanges();
                questionRepository.UpdateQuestionVotesCount(updateAnswer.QuestionID, voteValue);
                votesRepository.UpdateVote(updateAnswer.AnswerID, userId, voteValue);
            }
        }

        public void DeleteAnswer(int answerid)
        {
            Answer deleteAnswer = db.Answers.FirstOrDefault(a => a.AnswerID == answerid);
            if (deleteAnswer!=null)
            {
                db.Answers.Remove(deleteAnswer);
                questionRepository.UpdateQuestionAnswersCount(deleteAnswer.QuestionID,-1);
                
            }

        }

        public List<Answer> GetAnswersByQuestionId(int questionid)
        {
            List<Answer> answers = db.Answers.Where(a => a.QuestionID == questionid).OrderBy(a => a.AnswerDateAndTime).ToList();
            return answers;
        }

        public Answer GetAnswer(int answerid)
        {
            Answer answer = db.Answers.FirstOrDefault(a => a.AnswerID == answerid);
            return answer;
        }
    }
}
