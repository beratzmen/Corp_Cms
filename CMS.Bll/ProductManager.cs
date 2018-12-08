using CMS.Dal.Abstract.ProductDal;
using CMS.Entities;
using CMS.Interfaces;
using System.Collections.Generic;

namespace CMS.Bll
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public void Add(Product entity)
        {
            _productDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _productDal.Delete(Id);
        }

        public Product Get(int Id)
        {
            return _productDal.Get(Id);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public List<Product> GetElementByName(string productName)
        {
            return _productDal.GetElementByName(productName);
        }

        public void Update(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
