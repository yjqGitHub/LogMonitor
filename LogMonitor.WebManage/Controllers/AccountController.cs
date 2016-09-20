using LogMonitor.Application;
using LogMonitor.Infrastructure;
using LogMonitor.WebManage.Models;
using System.Web.Mvc;

namespace LogMonitor.WebManage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserApplication _userApplication;

        public AccountController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }

        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ValidationModel result = _userApplication.Login(model.UserName, model.Pwd);
                if (result.State == OperateResultTypeEnum.Success)
                {
                  return  RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("UserName", result.Content.ToString());
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "账号信息错误");
            }

            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}