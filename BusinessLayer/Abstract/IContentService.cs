using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListByWriter(int id);
        Content GetById(int id);
        List<Content> GetListByHeadingId(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        void ContentAdd(Content content);
    }
}
