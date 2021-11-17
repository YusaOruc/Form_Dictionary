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
    public class ContactManeger:IContactService
    {
        IContactDal _contactDal;

        public ContactManeger(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddBL(Contact entity)
        {
            _contactDal.Insert(entity);
        }

        public void DeleteBL(Contact entity)
        {
            _contactDal.Delete(entity);
        }

        public Contact GetByIDBL(int id)
        {
            return _contactDal.Get(x=>x.ContactID==id);
        }

        public List<Contact> GetListBL()
        {
            return _contactDal.List();
        }

        public void UpdateBL(Contact entity)
        {
            _contactDal.Update(entity);
        }
    }
}
