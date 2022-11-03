using Speed.Shared;
using System.Net.Http.Json;

namespace Speed.Client.Services.ScoreService
{
    public class ScoreService : IScoreService
    {
        private readonly HttpClient _http;
        public ScoreService(HttpClient http)
        {
            _http = http;
        }

        public List<Score> Scores { get; set; } = new List<Score>();

        public async Task GetScores()
        {
            var result = await _http.GetFromJsonAsync<List<Score>>("api/score");
            if (result != null)
            {
                Scores = result;
            }
        }

        public async Task GetSingleUserScore(string name)
        {
            var result = await _http.GetFromJsonAsync<List<Score>>($"api/score/{name}");
            if (result != null)
            {
                Scores = result;
            }
        }

        public async Task AddScore(Score score)
        {
            var result = await _http.PostAsJsonAsync("api/score", score);
            Console.WriteLine(result.Content);
        }
    }
}
