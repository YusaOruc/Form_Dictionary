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
    public class MessageManeger : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManeger(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddBL(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void DeleteBL(Message entity)
        {
            _messageDal.Delete(entity);
        }

        public Message GetByIDBL(int id)
        {
            return _messageDal.Get(x=>x.MessageID==id);
        }

        public List<Message> GetListBL()
        {
            return _messageDal.List();

        }

        public List<Message> GetListInboxBL(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
            
        }

        public List<Message> GetListSendBL(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void UpdateBL(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
