using CMS.Dal.Abstract.PagesDal;
using CMS.Interfaces.Pages;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.Pages
{

    public class PagesManager : IPagesService
    {
        IPagesDal _pagesDal;
        public PagesManager(IPagesDal pagesDal)
        {
            _pagesDal = pagesDal;
        }
        public void Add(Entities.Pages entity)
        {
            _pagesDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _pagesDal.Delete(Id);
        }

        public Entities.Pages Get(int Id)
        {
            return _pagesDal.Get(Id);
        }

        public List<Entities.Pages> GetAll()
        {
            return _pagesDal.GetAll();
        }

        public Entities.Pages GetElementByName(string pageName)
        {
            return _pagesDal.GetElementByName(pageName);
        }

        public void Update(Entities.Pages entity)
        {
            _pagesDal.Update(entity);
        }
    }
}
