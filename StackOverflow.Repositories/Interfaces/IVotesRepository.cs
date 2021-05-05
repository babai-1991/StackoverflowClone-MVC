namespace StackOverflow.Repositories.Interfaces
{
    public interface IVotesRepository
    {
        void UpdateVote(int updateAnswerAnswerId, int userId, int voteValue);
    }
}