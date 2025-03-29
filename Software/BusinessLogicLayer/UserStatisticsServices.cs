using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserStatisticsServices
    {
        public List<USER_STATISTICS> GetAllStatistics()
        {
            using (var repo = new UserStatisticsRepository())
            {
                List<USER_STATISTICS> statistics = repo.GetAllStatistics().ToList();
                return statistics;
            }
        }

        public List<USER_STATISTICS> GetStatisticsByUsername(string username)
        {
            using (var repo = new UserStatisticsRepository())
            {
                List<USER_STATISTICS> statistics = repo.GetStatisticsByUsername(username).ToList();
                return statistics;
            }
        }

        public List<string> GetMostAnsweredQuestion()
        {
            using (var repo = new UserStatisticsRepository())
            {
                List<string> statistics = repo.GetMostAnsweredQuestion().ToList();
                return statistics;
            }
        }
    }
}
