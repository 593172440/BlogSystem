using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comment:BaseEntity
    {
        [ForeignKey(nameof(User))]
        public int User_Id { get; set; }
        public User User { get; set; }
        public string Content { get; set; }

        [ForeignKey(nameof(Article))]
        public int Article_Id { get; set; }
        public Article Article { get; set; }
    }
}
