using CMS.Dal.Abstract.ReferenceDal;
using CMS.Interfaces.Reference;
using System.Collections.Generic;

namespace CMS.Bll.Concrete.Reference
{
    public class ReferenceManager : IReferenceService
    {
        IReferenceDal _referenceDal;
        public ReferenceManager(IReferenceDal referenceDal)
        {
            _referenceDal = referenceDal;
        }
        public void Add(Entities.Reference entity)
        {
            _referenceDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _referenceDal.Delete(Id);
        }

        public Entities.Reference Get(int Id)
        {
            return _referenceDal.Get(Id);
        }

        public List<Entities.Reference> GetAll()
        {
            return _referenceDal.GetAll();
        }

        public void Update(Entities.Reference entity)
        {
            _referenceDal.Update(entity);
        }
    }
}
