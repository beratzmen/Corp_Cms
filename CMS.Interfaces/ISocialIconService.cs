namespace CMS.Interfaces
{
    public interface ISocialIconService : IGenericService<CMS.Entities.SocialIcon>
    {
        CMS.Entities.SocialIcon GetElementByName(string productName);
    }
}
