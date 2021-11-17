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
    public class ImageFileManeger : IImageService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManeger(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void AddBL(ImageFile entity)
        {
            _imageFileDal.Insert(entity);
        }

        public void DeleteBL(ImageFile entity)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetByIDBL(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetListBL()
        {
            return _imageFileDal.List();
        }

        public void UpdateBL(ImageFile entity)
        {
            throw new NotImplementedException();
        }
    }
}
