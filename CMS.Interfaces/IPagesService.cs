namespace CMS.Interfaces.Pages
{
    public interface IPagesService : IGenericService<CMS.Entities.Pages>
    {

        CMS.Entities.Pages GetElementByName(string pageName);
    }
}
