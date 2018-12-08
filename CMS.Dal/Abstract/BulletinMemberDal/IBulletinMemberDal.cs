using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.NewsMemberDal
{
    public  interface IBulletinMemberDal
    {
        List<BulletinMember> GetAll();
        BulletinMember Get(int Id);
        void Add(BulletinMember entity);
        void Delete(int Id);
        void Update(BulletinMember entity);
    }
}
