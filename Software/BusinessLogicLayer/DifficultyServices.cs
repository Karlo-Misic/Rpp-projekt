using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public  class DifficultyServices
    {
        public List<DIFFICULTy> GetAllDifficulties()
        {
            using (var repo = new DifficultyRepository())
            {
                List<DIFFICULTy> difficulties = repo.GetAllDifficulties().ToList();
                return difficulties;
            }
        }
    }
}
