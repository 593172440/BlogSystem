﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.Models
{
    public class Article:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int GoodCount { get; set; }
        /// <summary>
        /// 反对数
        /// </summary>
        public int BadCount { get; set; }


        [ForeignKey(nameof(User))]
        public int User_Id { get; set; }
        public User User { get; set; }
    }
}
