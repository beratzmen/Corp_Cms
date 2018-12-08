using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.CategoryDal
{
    public interface ICategoryDal
    {
        List<Category> GetAll();
        Category Get(int Id);
        void Add(Category entity);
        void Delete(int Id);
        void Update(Category entity);
    }
}
