using BlogSystem.MVCWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogSystem.MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        [BlogSystemAuth]
        public ActionResult Index()
        {
            return View();
        }
        [BlogSystemAuth]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [BlogSystemAuth]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Models.UserViewModels.RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userManager = new BLL.UserManager();
                await userManager.RegisterAsync(model.Email, model.Password);
                return Content("注册成功");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Models.UserViewModels.LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var userLogin = new BLL.UserManager();
                if(await userLogin.LoginAsync(model.Email, model.Pwd))
                {
                    //跳转
                    //判断是用Session还是用cookie
                    if(model.RememberMe)
                    {
                        Response.Cookies.Add(new HttpCookie("loginName")
                        {
                            Value = model.Email,
                            Expires=DateTime.Now.AddDays(7)
                        });
                    }
                    else
                    {
                        Session["loginName"] = model.Email;
                    }
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "用户名或密码有就误");
                }
            }
            return View(model);
        }
    }
}