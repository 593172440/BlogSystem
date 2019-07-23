using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IArticleManager
    {
        /// <summary>
        /// 创建文章
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="categoryIds"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task CreateArticleAsync(string title, string content, int[] categoryIds, int userId);
        /// <summary>
        /// 创建类别
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task CreateCategoryAsync(string name,int userId);
        /// <summary>
        /// 获取所有的类别
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<Dto.BlogCategoryDto>> GetAllCategoryesAsync(int id);
        /// <summary>
        /// 根据用户id获取所有文章
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<List<Dto.ArticleDto>> GetAllArticlesByUserIdAsync(int userId);
        /// <summary>
        /// 根据用户名获取所有文章
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<List<Dto.ArticleDto>> GetAllArticlesByUserIdAsync(string email);
        /// <summary>
        /// 根据类型获取所有文章
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<Dto.ArticleDto>> GetAllArticlesByCategoryIdAsync(int categoryId);
        Task RemoveCategoryAsync(string name);
        Task EditCategoryAsync(int categoryId, string newCategoryName);
        Task RemoveArticleAsync(int articleId);
        Task EditArticleAsync(int articleId, string title, string content,int[] categoryIds);
    }
}
