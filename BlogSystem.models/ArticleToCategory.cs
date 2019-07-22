using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class ArticleToCategory:BaseEntity
    {
        [ForeignKey(nameof(BlogCategory))]
        public int BlogCategory_Id { get; set; }
        public BlogCategory BlogCategory { get; set; }
        [ForeignKey(nameof(Article))]
        public int Article_Id { get; set; }
        public Article Article { get; set; }
    }
}
