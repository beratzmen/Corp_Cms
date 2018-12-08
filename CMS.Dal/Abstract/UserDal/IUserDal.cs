using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.UserDal
{
    public interface IUserDal
    {
        List<User> GetAll();
        User Get(int Id);
        void Add(User entity);
        void Delete(int Id);
        void Update(User entity);
        User userLogin(string EMail, string sifre);
    }
}
