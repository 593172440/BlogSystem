using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class BlogCategoryService : BaseService<Models.BlogCategory>,IDAL.IBlogCategory
    {
        public BlogCategoryService() : base(new BlogContext())
        {
        }
    }
}
