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
    public class AdminAuthorizationManeger : IAdminAuthorizationService
    {
        IAdminDal _adminDal;

        public AdminAuthorizationManeger(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddBL(Admin entity)
        {
            _adminDal.Insert(entity);
        }

        public void DeleteBL(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Admin GetByIDBL(int id)
        {
            return _adminDal.Get(x=>x.AdminID==id);
        }

        public List<Admin> GetListBL()
        {
            return _adminDal.List();
        }

        public void UpdateBL(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
