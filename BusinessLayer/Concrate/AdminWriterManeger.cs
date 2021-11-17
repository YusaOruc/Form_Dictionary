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
    public class AdminWriterManeger : IAdminWriterService
    {

        IAdminWriterDal _adminWriterDal;

        public AdminWriterManeger(IAdminWriterDal adminWriterDal)
        {
            _adminWriterDal = adminWriterDal;
        }

        public Writer GetWriter(Writer writer)
        {
            return _adminWriterDal.GetWriterDal(writer);
        }

        
    }
}
