using CMS.Dal.Abstract.JobUserDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFJobUserDal : IJobUserDal
    {
        private CmsContext context = new CmsContext();

        public void Add(JobUser entity)
        {
            context.JobUser.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.JobUser.Remove(context.JobUser.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public JobUser Get(int Id)
        {
            return context.JobUser.FirstOrDefault(x => x.Id == Id);
        }

        public List<JobUser> GetAll()
        {
            return context.JobUser.ToList();
        }

        public void Update(JobUser entity)
        {
            JobUser jobUserToUpdate = context.JobUser.FirstOrDefault(x => x.Id == entity.Id);
            jobUserToUpdate.Name = entity.Name;
            jobUserToUpdate.SurName = entity.SurName;
            jobUserToUpdate.Date = entity.Date;
            jobUserToUpdate.Phone = entity.Phone;
            jobUserToUpdate.CV = entity.CV;
            jobUserToUpdate.JobID = entity.JobID;
            context.SaveChanges();
        }
    }
}
