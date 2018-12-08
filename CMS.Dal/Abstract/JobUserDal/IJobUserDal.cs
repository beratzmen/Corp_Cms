using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.JobUserDal
{
    public interface IJobUserDal
    {
        List<JobUser> GetAll();
        JobUser Get(int Id);
        void Add(JobUser entity);
        void Delete(int Id);
        void Update(JobUser entity);
    }
}
