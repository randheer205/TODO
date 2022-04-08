using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO.Models;

namespace TODO.CategoryData
{
    public class SqlCategoryData : ICategoryInterface
    {
        TasksAppContext _tac;
        public SqlCategoryData(TasksAppContext tac)
        {
            _tac = tac;
        }

        public Category AddCategory(Category category)
        {
            _tac.Categories.Add(category);
            _tac.SaveChanges();
            return category;
        }

        public void DeleteCategory(int id)
        {
            var oc = GetOneCategory(id);
            if(oc!=null)
            {
                _tac.Categories.Remove(oc);
            }
        }

        public List<Category> GetCategories()
        {
            return _tac.Categories.ToList();
        }

        public Category GetOneCategory(int id)
        {
            var result = _tac.Categories.Find(id);
            return result;
        }

        public Category UpdateCategory(Category category)
        {
            var oc = GetOneCategory(category.Id);
            oc.CategoryName = category.CategoryName;
            oc.IsDefault = category.IsDefault;
            _tac.Categories.Update(oc);
            _tac.SaveChanges();
            return category;
        }
    }
}
