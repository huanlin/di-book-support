using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ex0_Common.Services;

namespace Ex4_UnityMvc5.Controllers
{
    public class HomeController : Controller
    {
        private IHelloService _helloService;

        public HomeController(IHelloService service)
        {
            _helloService = service;
        }

        // GET: Hello
        public ActionResult Index()
        {
            return Content(_helloService.Hello());
        }
    }
}