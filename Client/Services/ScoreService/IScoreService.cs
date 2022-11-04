using Speed.Shared;

namespace Speed.Client.Services.ScoreService
{
    public interface IScoreService
    {
        List<Score> Scores { get; set; }

        Task GetScores();

        Task GetSingleUserScore(string name);

        Task AddScore(Score score);
    }
}
