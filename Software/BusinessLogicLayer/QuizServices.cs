using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class QuizServices
    {
        public async Task<List<TriviaQuestion>> GetTriviaQuestions(string difficulty, int categoryId)
        {
            string url = $"https://opentdb.com/api.php?amount=10&category={categoryId}&difficulty={difficulty.ToLower()}&type=multiple";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    TriviaApiResponse apiResponse = JsonConvert.DeserializeObject<TriviaApiResponse>(jsonResponse);

                    foreach (var question in apiResponse.Results)
                    {
                        question.Question = WebUtility.HtmlDecode(question.Question);
                        question.CorrectAnswer = WebUtility.HtmlDecode(question.CorrectAnswer);
                        for (int i = 0; i < question.IncorrectAnswers.Count; i++)
                        {
                            question.IncorrectAnswers[i] = WebUtility.HtmlDecode(question.IncorrectAnswers[i]);
                        }
                    }

                    return apiResponse.Results;
                }
                else
                {
                    throw new Exception("Failed to retrieve data from API.");
                }
            }
        }

        public void SaveQuizResults(string username, string category, int correctAnswers, string mostAnsweredQuestion)
        {
            using (var userRepo = new UserRepository())
            {
                int userId = userRepo.GetUserIdByUsername(username);

                using (var statsRepo = new UserStatisticsRepository())
                {
                    statsRepo.SaveQuizStatistics(userId, category, correctAnswers, mostAnsweredQuestion);
                }
            }
        }
    }
}
