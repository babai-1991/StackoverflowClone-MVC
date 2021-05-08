using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using StackOverflow.DomainModels;
using StackOverflow.Repositories;
using StackOverflow.Repositories.Interfaces;
using StackOverflow.ServiceLayer.Interfaces;
using StackOverflow.ViewModels;

namespace StackOverflow.ServiceLayer
{
    class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository = null;

        public QuestionService()
        {
            _questionRepository = new QuestionRepository();
        }
        public void InsertQuestion(NewQuestionViewModel newQuestionViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<NewQuestionViewModel, Question>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();
            Question question = mapper.Map<NewQuestionViewModel, Question>(newQuestionViewModel);
            _questionRepository.InsertQuestion(question);
        }

        public void UpdateQuestionDetails(EditQuestionViewModel editQuestionViewModel)
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<EditQuestionViewModel, Question>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();
            Question question = mapper.Map<EditQuestionViewModel, Question>(editQuestionViewModel);
            _questionRepository.UpdateQuestionDetails(question);
        }

        public void UpdateQuestionVotesCount(int questionId, int value)
        {
            _questionRepository.UpdateQuestionVotesCount(questionId, value);
        }

        public void UpdateQuestionAnswerCount(int questionid, int value)
        {
            _questionRepository.UpdateQuestionAnswersCount(questionid, value);
        }

        public void UpdateQuestionViewCount(int questionId)
        {
            _questionRepository.UpdateQuestionViewsCount(questionId);
        }

        public void DeleteQuestion(int questionId)
        {
            _questionRepository.DeleteQuestion(questionId);
        }

        public List<QuestionViewModel> GetQuestions()
        {
            List<Question> questions = _questionRepository.GetQuestions();
            var configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Question, QuestionViewModel>();
                config.IgnoreUnMapped();
            });

            IMapper mapper = configuration.CreateMapper();
            List<QuestionViewModel> questionList = mapper.Map<List<Question>, List<QuestionViewModel>>(questions);
            return questionList;
        }

        public QuestionViewModel GetQuestionByQuestionId(int questionid, int userId)
        {
            Question question = _questionRepository.GetQuestionByQuestionId(questionid);
            QuestionViewModel questionViewModel = null;
            if (question != null)
            {
                var configuration = new MapperConfiguration(config =>
                {
                    config.CreateMap<Question, QuestionViewModel>();
                    config.IgnoreUnMapped();
                });

                IMapper mapper = configuration.CreateMapper();
                questionViewModel = mapper.Map<Question, QuestionViewModel>(question);

                //load corresponding answers..
                foreach (var answer in questionViewModel.Answers)
                {
                    /*OK so current working user is suppose Babai and opened the Questionid 1
                     And suppose it has 10 answers. So for any of those answers, Babai has given which vote I want to clearify.
                    Suppose on first answer he gives upvote but for next answer he gives upvote and so on..

                    I want to store that information in this particular CurrentUserGivenVoteType property.
                     */
                    answer.CurrentUserGivenVoteType = 0;
                    VoteViewModel vote = answer.Votes.FirstOrDefault(a => a.UserId == userId);
                    if (vote != null)
                    {
                        answer.CurrentUserGivenVoteType = vote.VoteValue;
                    }
                }
            }
            return questionViewModel;
        }
    }
}
