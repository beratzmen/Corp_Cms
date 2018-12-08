using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.BulletinDal
{
    public  interface IBulletinDal
    {
        List<Bulletin> GetAll();
        Bulletin Get(int Id);
        void Add(Bulletin entity);
        void Delete(int Id);
        void Update(Bulletin entity);
    }
}
