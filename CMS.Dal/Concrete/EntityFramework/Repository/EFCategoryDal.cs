using CMS.Dal.Abstract.CategoryDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFCategoryDal : ICategoryDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Category entity)
        {
            context.Category.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Category.Remove(context.Category.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Category Get(int Id)
        {
            return context.Category.FirstOrDefault(x => x.Id == Id);
        }

        public List<Category> GetAll()
        {
            return context.Category.ToList();
        }

        public void Update(Category entity)
        {
            Category categoryToUpdate = context.Category.FirstOrDefault(x => x.Id == entity.Id);
            categoryToUpdate.Name = entity.Name;
            categoryToUpdate.Description = entity.Description;
           
            context.SaveChanges();
        }
    }
}
