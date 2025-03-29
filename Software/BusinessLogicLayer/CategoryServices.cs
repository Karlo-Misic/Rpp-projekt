using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BusinessLogicLayer
{
    public class CategoryServices
    {
        public List<CATEGORy> GetAllCategories()
        {
            using (var repo = new CategoryRepository())
            {
                List<CATEGORy> categories = repo.GetAllCategories().ToList();

                if (categories == null || categories.Count == 0)
                {
                    Debug.WriteLine("Categories not fetched!");
                }
                else
                {
                    Debug.WriteLine($"Fetched {categories.Count} categories from base.");
                }

                return MapCategoryIDs(categories);
            }
        }


        private List<CATEGORy> MapCategoryIDs(List<CATEGORy> categories)
        {
            Dictionary<int, int> categoryIDMapping = new Dictionary<int, int>
    {
        { 1, 11 },
        { 2, 23 },
        { 3, 15 },
        { 4, 22 },
        { 5, 12 },
        { 6, 17 },
        { 7, 17 },
        { 8, 9 },
        { 9, 21 },
        { 10, 18 }
    };

            foreach (var category in categories)
            {
                if (categoryIDMapping.ContainsKey(category.categoryID))
                {
                    category.categoryID = categoryIDMapping[category.categoryID];
                }
                Debug.WriteLine($"Mapped: {category.name} -> {category.categoryID}");
            }

            return categories;
        }

    }
}
