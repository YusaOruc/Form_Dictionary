using EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService : IRepositoryService<Content>
    {
        List<Content> GetListByIDBL(int id);
        List<Content> GetListSerch(string p);
        List<Content> GetListByWriterIDBL(int id);
    }
}
