using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.ProductDal
{
    public interface IProductDal
    {
        List<Product> GetAll();
        Product Get(int Id);
        void Add(Product entity);
        void Delete(int Id);
        void Update(Product entity);
        List<Product> GetElementByName(string productName);
    }
}
