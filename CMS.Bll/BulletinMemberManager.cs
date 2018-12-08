using CMS.Dal.Abstract.NewsMemberDal;
using CMS.Interfaces.NewsMember;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.NewsMember
{
    public class BulletinMemberManager : IBulletinMemberService
    {
        IBulletinMemberDal _bulletinMemberDal;
        public BulletinMemberManager(IBulletinMemberDal bulletinMemberDal)
        {
            _bulletinMemberDal = bulletinMemberDal;
        }
        public void Add(Entities.BulletinMember entity)
        {
            _bulletinMemberDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _bulletinMemberDal.Delete(Id);
        }

        public Entities.BulletinMember Get(int Id)
        {
            return _bulletinMemberDal.Get(Id);
        }

        public List<Entities.BulletinMember> GetAll()
        {
            return _bulletinMemberDal.GetAll();
        }

        public void Update(Entities.BulletinMember entity)
        {
            _bulletinMemberDal.Update(entity);
        }
    }
}
