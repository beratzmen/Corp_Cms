using System.Collections.Generic;

namespace CMS.Interfaces
{
    public interface IGenericService<T>
    {
        List<T> GetAll();
        T Get(int Id);
        void Add(T entity);
        void Delete(int Id);
        void Update(T entity);
    }
}
