using CMS.Dal.Abstract.UserDal;
using CMS.Interfaces.User;
using System;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.User
{

    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Add(Entities.User entity)
        {
            var sifre = new ToPasswordRepository().Sha1(entity.Password);
            entity.Password = sifre;
            _userDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _userDal.Delete(Id);
        }

        public Entities.User Get(int Id)
        {
            return _userDal.Get(Id);
        }

        public List<Entities.User> GetAll()
        {
            return _userDal.GetAll();
        }

        public void Update(Entities.User entity)
        {
            var sifre = new ToPasswordRepository().Sha1(entity.Password);
            entity.Password = sifre;
            _userDal.Update(entity);
        }

        public Entities.User userLogin(string EMail, string Password)
        {
            try
            {
                if (string.IsNullOrEmpty(EMail.Trim()) || string.IsNullOrEmpty(Password.Trim()))
                {
                    throw new Exception("EMail veya Parola Boş Geçilemez..");
                }
                var sifre = new ToPasswordRepository().Sha1(Password);
                var user = _userDal.userLogin(EMail, sifre);
                if (user == null)
                {
                    throw new Exception("Kullanıcı ve Parola Uyuşmuyor");
                }
                else
                {
                    return user;
                }
            }
            catch (Exception)
            {
                throw new Exception("Kullanıcı Giriş Hata :");
            }
        }
    }
}
