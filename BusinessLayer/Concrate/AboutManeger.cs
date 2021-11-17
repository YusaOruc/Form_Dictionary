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
    public class AboutManeger : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManeger(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AddBL(About entity)
        {
            _aboutDal.Insert(entity);
        }

        public void DeleteBL(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public About GetByIDBL(int id)
        {
            return _aboutDal.Get(x=>x.AboutID==id);
        }

        public List<About> GetListBL()
        {
            return _aboutDal.List();
        }

        public void UpdateBL(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}
