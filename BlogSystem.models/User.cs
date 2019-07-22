using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class User:BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 头像地址
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// 粉丝数
        /// </summary>
        public int FansCount { get; set; }
        /// <summary>
        /// 关注数
        /// </summary>
        public int FocusCount { get; set; }
        /// <summary>
        /// 网站名
        /// </summary>
        public string SiteName { get; set; }
    }
}
