using CMS.Dal.Abstract.ProductDal;
using CMS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CMS.Dal.Concrete.EntityFramework.Repository
{
    public class EFProductDal : IProductDal
    {
        private CmsContext context = new CmsContext();

        public void Add(Product entity)
        {
            context.Product.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int Id)
        {
            context.Product.Remove(context.Product.FirstOrDefault(x => x.Id == Id));
            context.SaveChanges();
        }

        public Product Get(int Id)
        {
            return context.Product.FirstOrDefault(x => x.Id == Id);
        }

        public List<Product> GetAll()
        {
            return context.Product.ToList();
        }

        public List<Product> GetElementByName(string productName)
        {
            //Product search = context.Product.FirstOrDefault(x => x.Name == productName);
            var search = context.Product.Where(s => s.Name.Contains(productName));
            return search.ToList();
        }

        public void Update(Product entity)
        {
            Product productToUpdate = context.Product.FirstOrDefault(x => x.Id == entity.Id);
            productToUpdate.Name = entity.Name;
            productToUpdate.Description = entity.Description;
            productToUpdate.NameEN = entity.NameEN;
            productToUpdate.DescriptionEN = entity.DescriptionEN;
            productToUpdate.Price = entity.Price;
            productToUpdate.Image = entity.Image;
            context.SaveChanges();
        }
    }
}
