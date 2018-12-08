
using CMS.Dal.Abstract.ReferenceDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFReferenceDal : IReferenceDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Reference entity)
        {
            context.Reference.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Reference.Remove(context.Reference.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Reference Get(int Id)
        {
            return context.Reference.FirstOrDefault(x => x.Id == Id);
        }

        public List<Reference> GetAll()
        {
            return context.Reference.ToList();
        }

        public void Update(Reference entity)
        {
            Reference referenceToUpdate = context.Reference.FirstOrDefault(x => x.Id == entity.Id);
            referenceToUpdate.Name = entity.Name;
            referenceToUpdate.Sites = entity.Sites;
            referenceToUpdate.Image = entity.Image;
            context.SaveChanges();
        }
    }
}
