using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DifficultyRepository : Repository<DIFFICULTy>
    {
        public DifficultyRepository() : base(new DataBase())
        {

        }

        public override IQueryable<DIFFICULTy> GetAllDifficulties()
        {
            var query = from d in Entities
                        select d;
            return query;
        }
    }
}
