using System.Collections.Generic;

namespace CMS.Interfaces
{
    public interface IProductService : IGenericService<CMS.Entities.Product>
    {
        List<CMS.Entities.Product> GetElementByName(string productName);
    }
}
