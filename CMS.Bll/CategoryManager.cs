using CMS.Dal.Abstract.CategoryDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }
        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _categoryDal.Delete(Id);
        }

        public Category Get(int Id)
        {
            return _categoryDal.Get(Id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void Update(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
