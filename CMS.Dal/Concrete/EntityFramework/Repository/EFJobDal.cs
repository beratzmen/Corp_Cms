using CMS.Dal.Abstract.JobDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFJobDal : IJobDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Job entity)
        {
            context.Job.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {           
            context.Job.Remove(context.Job.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Job Get(int Id)
        {
            return context.Job.FirstOrDefault(x => x.Id == Id);
        }

        public List<Job> GetAll()
        {
            return context.Job.ToList();
        }

        public void Update(Job entity)
        {
            Job jobToUpdate = context.Job.FirstOrDefault(x => x.Id == entity.Id);
            jobToUpdate.Title = entity.Title;
            jobToUpdate.TitleEN = entity.TitleEN;
            jobToUpdate.Content = entity.Content;
            jobToUpdate.ContentEN = entity.ContentEN;
            jobToUpdate.Date = entity.Date;
            context.SaveChanges();
        }
    }
}
