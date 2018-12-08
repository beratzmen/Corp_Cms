using CMS.Dal.Abstract.JobDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class JobManager : IJobService
    {
        IJobDal _jobDal;
        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }
        public void Add(Job entity)
        {
            _jobDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _jobDal.Delete(Id);
        }

        public Job Get(int Id)
        {
            return _jobDal.Get(Id);
        }

        public List<Job> GetAll()
        {
            return _jobDal.GetAll();
        }

        public void Update(Job entity)
        {
            _jobDal.Update(entity);
        }
    }
}
