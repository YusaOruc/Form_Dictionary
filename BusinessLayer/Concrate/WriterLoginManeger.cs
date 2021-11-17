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
    public class WriterLoginManeger:IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManeger(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDal.Get(x=>x.WriterMail==username && x.WriterPassword==password);
        }
    }
}
