using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRepositoryService<T> where T : class
    {
        List<T> GetListBL();
        void AddBL(T entity);
        T GetByIDBL(int id);
        void DeleteBL(T entity);
        void UpdateBL(T entity);
    }
}
