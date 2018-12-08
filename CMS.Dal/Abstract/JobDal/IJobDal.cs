using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.JobDal
{
    public interface IJobDal
    {
        List<Job> GetAll();
        Job Get(int Id);
        void Add(Job entity);
        void Delete(int Id);
        void Update(Job entity);
    }
}
