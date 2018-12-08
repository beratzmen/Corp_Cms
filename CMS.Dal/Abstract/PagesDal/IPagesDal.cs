using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.PagesDal
{
    public interface IPagesDal
    {
        List<Pages> GetAll();
        Pages Get(int Id);
        Pages GetElementByName(string pageName);
        void Add(Pages entity);
       
        void Delete(int Id);
        void Update(Pages entity);
    }
}
