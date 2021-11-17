using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class GenericRepositoryService<T,TDal> : IRepositoryService<T> where T : class
    {
        Context context = new Context();
        TDal _object;
        public GenericRepositoryService(TDal entity)
        {
            _object = entity;
        }
        public void AddBL(T entity)
        {
            //_object.ins
        }

        public void DeleteBL(T entity)
        {
            throw new NotImplementedException();
        }

        public T GetByIDBL(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetListBL()
        {
            throw new NotImplementedException();
        }

        public void UpdateBL(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
