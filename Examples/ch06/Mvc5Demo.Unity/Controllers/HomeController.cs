using Examples.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5Demo.Unity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController(IMessageService msgSvc)
        {
            _messageService = msgSvc;
        }

        // GET: Home
        public ActionResult Index()
        {
            return Content(_messageService.Hello("MVC5 with Unity!"));
        }
    }
}