using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntitiyFramework
{
    public class EFAdminDal : GenericRepository<Admin>, IAdminDal
    {
        Context context = new Context();
        public Admin GetAdminDal(Admin admin)
        {
            return context.Admins.FirstOrDefault(x => x.AdminName == admin.AdminName && x.AdminPassword == admin.AdminPassword);
        }
    }
}
