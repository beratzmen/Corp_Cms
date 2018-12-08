using CMS.Dal.Abstract.NewsDal;
using CMS.Interfaces.News;
using System.Collections.Generic;


namespace CMS.Bll.Concrete.News
{
    public class NewsManager : INewsService
    {
        INewsDal _newsDal;

        public NewsManager(INewsDal newsDal)
        {
            _newsDal = newsDal;
        }
        public void Add(Entities.News entity)
        {
            _newsDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _newsDal.Delete(Id);
        }

        public Entities.News Get(int Id)
        {
            return _newsDal.Get(Id);
        }

        public List<Entities.News> GetAll()
        {
            return _newsDal.GetAll();

        }


        public void Update(Entities.News entity)
        {
            _newsDal.Update(entity);
        }
    }
}
