namespace CMS.Interfaces.User
{
    public interface IUserService : IGenericService<CMS.Entities.User>
    {
        CMS.Entities.User userLogin(string EMail, string Password);
    }
}
