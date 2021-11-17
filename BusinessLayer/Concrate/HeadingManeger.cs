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
    public class HeadingManeger: IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManeger(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddBL(Heading entity)
        {
            _headingDal.Insert(entity);
        }

        public void DeleteBL(Heading entity)
        {
            
            _headingDal.Update(entity);
        }

        public Heading GetByIDBL(int id)
        {
            return _headingDal.Get(x=>x.HeadingID==id);
        }

        public List<Heading> GetListBL()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void UpdateBL(Heading entity)
        {
            _headingDal.Update(entity);
        }
    }
}
