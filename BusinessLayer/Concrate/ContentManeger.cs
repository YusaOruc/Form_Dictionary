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
    public class ContentManeger : IContentService
    {
        IContentDal _contentDal;

        public ContentManeger(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddBL(Content entity)
        {
            _contentDal.Insert(entity);
        }

        public void DeleteBL(Content entity)
        {
            _contentDal.Delete(entity);
        }

        
        public Content GetByIDBL(int id)
        {
            throw new NotImplementedException();
        }

       
        public List<Content> GetListBL()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByIDBL(int id)
        {
           
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriterIDBL(int id)
        {
            return _contentDal.List(x=>x.WriterID==id);
        }

        public List<Content> GetListSerch(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));

        }

        public void UpdateBL(Content entity)
        {
            throw new NotImplementedException();
        }
    }
}
