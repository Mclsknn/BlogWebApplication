using BlogWebApplicationEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogWebApplication.Business.Abstract
{
    public interface ICommentService : IService<Comment>
    {
        IList<Comment> GetCommentsByBlogID(int BlogID);
    }
}
