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
    public class AdminManeger : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManeger(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddBL(Admin entity)
        {
            _adminDal.Insert(entity);
        }

        public void DeleteBL(Admin entity)
        {
            _adminDal.Delete(entity);
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

        public Admin GetAdmin(Admin admin)
        {
            return _adminDal.GetAdminDal(admin);
        }
    }
}
