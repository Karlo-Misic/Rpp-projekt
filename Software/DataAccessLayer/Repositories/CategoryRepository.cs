using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer.Entities;

namespace DataAccessLayer.Repositories
{
    public class CategoryRepository : Repository<CATEGORy>
    {
        public CategoryRepository() : base(new DataBase())
        {

        }

        public override IQueryable<CATEGORy> GetAllCategories()
        {
            var query = from c in Entities
                        select c;
            return query;
        }
    }
}
