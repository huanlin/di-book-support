using System;
using System.Web.Mvc;
using Examples.Common.Services;

namespace Mvc5Demo.Unity.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService _messageService;

        public HomeController(IMessageService msgSvc)
        {
            _messageService = msgSvc;
        }

        public ActionResult Index()
        {
            return Content(_messageService.Hello("MVC5 with Unity!"));
        }
    }
}