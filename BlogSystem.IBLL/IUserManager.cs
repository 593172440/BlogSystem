using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSystem.IBLL
{
    public interface IUserManager
    {
        Task RegisterAsync(string email, string password);
        Task<bool> LoginAsync(string email, string password);
        Task ChangePasswordAsync(string email, string oldPwd, string newPwd);
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="email"></param>
        /// <param name="siteName"></param>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        Task ChangeUserInformationAsync(string email, string siteName, string imagePath);
        /// <summary>
        /// 得到用户信息
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Dto.UserInformationDto GetUserByEmail(string email);
    }
}
