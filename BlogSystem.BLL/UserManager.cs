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
                if (await LoginAsync(email, oldPwd))
                {
                    var user = await userSvc.GetAll().FirstAsync(m => m.Email == email);
                    user.Password = newPwd;
                    await userSvc.EditAsync(user);
                }
            }
        }
        public async Task ChangeUserInformationAsync(string email, string siteName, string imagePath)
        {
            using (var userSvc = new DAL.UserService())
            {
                await userSvc.EditAsync(new Models.User() { Email = email, SiteName = siteName, ImagePath = imagePath });
                //var user= await userSvc.GetAll().FirstAsync(m => m.Email == email);
                //user.SiteName = siteName;
                //user.ImagePath = imagePath;
                //await userSvc.EditAsync(user);
            }
        }
        /// <summary>
        /// 获取用户信息并转换到dto
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<UserInformationDto> GetUserByEmailAsync(string email)
        {
            //model-->dto;数据转换
            using (var user = new DAL.UserService())
            {
                if (await user.GetAll().AnyAsync(m => m.Email == email))
                {
                    return await user.GetAll().Where(m => m.Email == email).Select(m => new Dto.UserInformationDto()
                    {
                        Id = m.Id,
                        Email = m.Email,
                        FancCount = m.FansCount,
                        FocusCount = m.FocusCount,
                        ImagePath = m.ImagePath,
                        SiteName = m.SiteName
                    }).FirstAsync();
                }
                else
                {
                    throw new ArgumentException("邮箱不存在");
                }
            }
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
                    ImagePath = "default.png"
                });
            }
        }
    }
}
