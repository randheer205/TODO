using System.Collections.Generic;
using TODO.Models;

namespace TODO.CategoryData
{
    public interface ICategoryInterface
    {
        List<Category> GetCategories();

        Category AddCategory(Category category);

        Category UpdateCategory(Category category);

        void DeleteCategory(int id);

        Category GetOneCategory(int id);

    }
}
