using DataAccessLayer;
using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class QuestionServices
    {
        public bool AddQuestion(QUESTION question)
        {
            bool isSuccessful = false;
            try
            {
                using (var repo = new QuestionRepository())
                {
                    int affectedRows = repo.Add(question);
                    isSuccessful = affectedRows > 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error while fetching questions: " + ex.Message);
            }
            return isSuccessful;
        }
    }
}
