using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.CategoryData
{

    public class MockCategoryData : ICategoryInterface
    {
        private List<Category> categories = new List<Category>()
        {
            new Category()
            {
                Id=101,
                IsDefault=true,
                CategoryName="Action"
            },
            new Category()
            {
                Id=102,
                IsDefault=false,
                CategoryName="Fantasy"
            }
        };

        public Category AddCategory(Category category)
        {
            categories.Add(category);
            return category;
        }

        public void DeleteCategory(int id)
        {
            
        }

        public List<Category> GetCategories()
        {
            return categories;
        }

        public Category GetOneCategory(int id)
        {
            return categories.SingleOrDefault(x => x.Id == id) ;
        }

        public Category UpdateCategory(Category category)
        {
            var cat = GetOneCategory(category.Id);
                cat.CategoryName = category.CategoryName;
                cat.IsDefault = category.IsDefault;
                return category;
        }
    }
}
