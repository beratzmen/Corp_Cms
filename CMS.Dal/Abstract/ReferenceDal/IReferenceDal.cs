using CMS.Entities;
using System.Collections.Generic;

namespace CMS.Dal.Abstract.ReferenceDal
{
    public interface IReferenceDal
    {
        List<Reference> GetAll();
        Reference Get(int Id);
        void Add(Reference entity);
        void Delete(int Id);
        void Update(Reference entity);
    }
}
