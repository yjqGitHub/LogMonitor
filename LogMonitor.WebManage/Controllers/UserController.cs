using LogMonitor.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LogMonitor.WebManage.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserApplication _userApplication;
        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
    }
}