using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrate.Repositories;
using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrate
{
    public class CategoryManeger :ICategorySevice
    {
        ICategoryDal _categoryDal;

        public CategoryManeger(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddBL(Category entity)
        {
            _categoryDal.Insert(entity);
        }

      

       
        public void DeleteBL(Category entity)
        {
            _categoryDal.Delete(entity);
        }

      

        public Category GetByIDBL(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

       

        public List<Category> GetListBL()
        {
            return _categoryDal.List();
        }

        public void UpdateBL(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
