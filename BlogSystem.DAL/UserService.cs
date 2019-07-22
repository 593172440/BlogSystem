using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogSystem.Models;

namespace BlogSystem.DAL
{
    public class UserService : BaseService<Models.User>, IDAL.IUserService
    {
        public UserService() : base(new Models.BlogContext())
        {
        }
    }
}
