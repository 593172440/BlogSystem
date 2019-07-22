using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Dto;
using System.Data.Entity;
namespace BlogSystem.BLL
{
    public class UserManager : IBLL.IUserManager
    {
        public async Task ChangePasswordAsync(string email, string oldPwd, string newPwd)
        {
            using (var userSvc = new DAL.UserService())
            {
                if(await LoginAsync(email,oldPwd))
                {
                    var user = await userSvc.GetAll().FirstAsync(m => m.Email == email);
                    user.Password = newPwd;
                    await userSvc.EditAsync(user);
                }
                else
                {

                }
            }

        }

        public Task ChangeUserInformationAsync(string email, string siteName, string imagePath)
        {
            throw new NotImplementedException();
        }

        public UserInformationDto GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginAsync(string email, string password)
        {
            using (var userSvc = new DAL.UserService())
            {
                return await userSvc.GetAll().AnyAsync(m => m.Email == email && m.Password == password);
            }
        }
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task RegisterAsync(string email, string password)
        {
            using (var userSvc = new DAL.UserService())
            {
                await userSvc.CreateAsync(new Models.User()
                {
                    Email = email,
                    Password = password,
                    SiteName = "默认的小站",
                    ImagePath="default.png"
                });
            }
        }
    }
}
