using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class WriterManeger : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManeger(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void AddBL(Writer entity)
        {
            _writerDal.Insert(entity);
        }

        public void DeleteBL(Writer entity)
        {
            _writerDal.Delete(entity);
        }

        public Writer GetByIDBL(int id)
        {
            return _writerDal.Get(x=>x.WriterID==id);
        }

        public List<Writer> GetListBL()
        {
            return _writerDal.List();
        }

        public void UpdateBL(Writer entity)
        {
            _writerDal.Update(entity);
        }
    }
}
