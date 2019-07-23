using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class ArticleToCategory : BaseService<Models.ArticleToCategory>, IDAL.IArticleToCategory
    {
        public ArticleToCategory() : base(new BlogContext())
        {
        }
    }
}
