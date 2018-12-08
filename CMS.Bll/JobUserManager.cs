using CMS.Dal.Abstract.JobUserDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class JobUserManager : IJobUserService
    {
        IJobUserDal _jobUserDal;
        public JobUserManager(IJobUserDal jobUserDal)
        {
            _jobUserDal = jobUserDal;
        }
        public void Add(JobUser entity)
        {
            _jobUserDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _jobUserDal.Delete(Id);
        }

        public JobUser Get(int Id)
        {
            return _jobUserDal.Get(Id);
        }

        public List<JobUser> GetAll()
        {
            return _jobUserDal.GetAll();
        }

        public void Update(JobUser entity)
        {
            _jobUserDal.Update(entity);
        }
    }
}
