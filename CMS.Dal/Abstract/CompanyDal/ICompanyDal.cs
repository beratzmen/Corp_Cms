using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.CompanyDal
{
    public interface ICompanyDal
    {
        List<Company> GetAll();
        Company Get(int Id);
        void Add(Company entity);
        void Delete(int Id);
        void Update(Company entity);
    }
}
