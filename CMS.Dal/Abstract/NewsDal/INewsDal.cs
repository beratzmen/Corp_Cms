using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.NewsDal
{
    public  interface INewsDal
    {
        List<News> GetAll();
        News Get(int Id);
        void Add(News entity);
        void Delete(int Id);
        void Update(News entity);
       
    }
}
