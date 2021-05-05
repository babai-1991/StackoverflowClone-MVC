using System.Linq;
using StackOverflow.DomainModels;
using StackOverflow.Repositories.Interfaces;

namespace StackOverflow.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly StackOverflowDbContext db;

        public VotesRepository()
        {
            db = new StackOverflowDbContext();
        }
        public void UpdateVote(int updateAnswerAnswerId, int userId, int voteValue)
        {
            int updateVoteValue = 0;
            if (voteValue > 0)
            {
                updateVoteValue = 1;
            }
            else if (voteValue < 0)
            {
                updateVoteValue = -1;
            }

            Vote vote = db.Votes.FirstOrDefault(v => v.AnswerID == updateAnswerAnswerId && v.UserID == userId);
            if (vote != null)
            {
                vote.VoteValue = updateVoteValue;
            }
            else
            {
                var newVote = new Vote()
                {
                    AnswerID = updateAnswerAnswerId,
                    UserID = userId,
                    VoteValue = voteValue
                };
                db.Votes.Add(newVote);
            }
            db.SaveChanges();
        }
    }
}