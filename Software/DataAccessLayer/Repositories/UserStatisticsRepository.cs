using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserStatisticsRepository : Repository<USER_STATISTICS>
    {
        public UserStatisticsRepository() : base(new DataBase())
        {
        }

        public override IQueryable<USER_STATISTICS> GetAllStatistics()
        {
            var query = from s in Entities
                        select s;
            return query;
        }

        public IQueryable<USER_STATISTICS> GetStatisticsByUsername(string username)
        {
            var query = from s in Entities
                        where s.USER.username == username
                        select s;
            return query;
        }

        public IQueryable<string> GetMostAnsweredQuestion()
        {
            var query = from s in Entities
                        select s.mostAnsweredQuestion;
            return query;
        }

        public void SaveQuizStatistics(int userId, string category, int correctAnswers, string mostAnsweredQuestion)
        {
            var userStatistics = new USER_STATISTICS
            {
                userID = userId,
                category = category,
                correctAnswers = correctAnswers,
                totalQuestions = 10,
                mostAnsweredQuestion = mostAnsweredQuestion,
                correctPercentage = (double)correctAnswers / 10
            };

            Entities.Add(userStatistics);
            SaveChanges();
        }
    }
}
