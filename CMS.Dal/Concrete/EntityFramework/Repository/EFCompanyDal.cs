using CMS.Dal.Abstract.CompanyDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFCompanyDal : ICompanyDal
    {
        private CmsContext context = new CmsContext();
        public void Add(Company entity)
        {
            context.Company.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Company.Remove(context.Company.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Company Get(int Id)
        {
            return context.Company.FirstOrDefault(x => x.Id == Id);
        }

        public List<Company> GetAll()
        {
            return context.Company.ToList();
        }

        public void Update(Company entity)
        {
            Company companyToUpdate = context.Company.FirstOrDefault(x => x.Id == entity.Id);
            companyToUpdate.Name = entity.Name;
            companyToUpdate.Phone = entity.Phone;
            companyToUpdate.EMail = entity.EMail;
            companyToUpdate.Adress = entity.Adress;
            companyToUpdate.Description = entity.Description;
            companyToUpdate.FullName = entity.FullName;
            companyToUpdate.Map = entity.Map;
            context.SaveChanges();
        }
    }
}
