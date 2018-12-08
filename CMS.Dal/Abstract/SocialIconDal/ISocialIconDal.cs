using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.SocialIconDal
{
    public interface ISocialIconDal
    {
        List<SocialIcon> GetAll();
        SocialIcon Get(int Id);
        void Add(SocialIcon entity);
        void Delete(int Id);
        void Update(SocialIcon entity);
        SocialIcon GetElementByName(string productName);
    }
}
