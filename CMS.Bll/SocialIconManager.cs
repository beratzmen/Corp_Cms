using CMS.Dal.Abstract.SocialIconDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class SocialIconManager : ISocialIconService
    {
        ISocialIconDal _socialIconDal;
        public SocialIconManager(ISocialIconDal socialIconDal)
        {
            this._socialIconDal = socialIconDal;
        }
        public void Add(SocialIcon entity)
        {
            _socialIconDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _socialIconDal.Delete(Id);
        }

        public SocialIcon Get(int Id)
        {
            return _socialIconDal.Get(Id);
        }

        public List<SocialIcon> GetAll()
        {
            return _socialIconDal.GetAll();
        }

        public SocialIcon GetElementByName(string productName)
        {
            return _socialIconDal.GetElementByName(productName);
        }

        public void Update(SocialIcon entity)
        {
            _socialIconDal.Update(entity);
        }
    }
}
