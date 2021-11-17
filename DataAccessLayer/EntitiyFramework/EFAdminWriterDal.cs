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
    public class EFAdminWriterDal : GenericRepository<Writer>, IAdminWriterDal
    {
        Context context = new Context();
        public Writer GetWriterDal(Writer writer)
        {
            return context.Writers.FirstOrDefault(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
        }
    }
}
