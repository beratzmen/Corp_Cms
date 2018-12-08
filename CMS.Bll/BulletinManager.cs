using CMS.Dal.Abstract.BulletinDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class BulletinManager : IBulletinService
    {
        IBulletinDal _bulletinDal;
        public BulletinManager(IBulletinDal bulletinDal)
        {
            _bulletinDal = bulletinDal;
        }
        public void Add(Bulletin entity)
        {
            _bulletinDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _bulletinDal.Delete(Id);
        }

        public Bulletin Get(int Id)
        {
            return _bulletinDal.Get(Id);
        }

        public List<Bulletin> GetAll()
        {
            return _bulletinDal.GetAll();
        }

        public void Update(Bulletin entity)
        {
            _bulletinDal.Update(entity);
        }
    }
}
