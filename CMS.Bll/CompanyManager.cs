using CMS.Dal.Abstract.CompanyDal;
using CMS.Interfaces.Company;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.Company
{
    public class CompanyManager : ICompanyService
    {
        ICompanyDal _companyDal;
        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }
        public void Add(Entities.Company entity)
        {
            _companyDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _companyDal.Delete(Id);
        }

        public Entities.Company Get(int Id)
        {
            return _companyDal.Get(Id);
        }

        public List<Entities.Company> GetAll()
        {
            return _companyDal.GetAll();
        }

        public void Update(Entities.Company entity)
        {
            _companyDal.Update(entity);
        }
    }
}
