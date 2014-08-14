using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ex4_UnityMvc5.Controllers
{
    public class QooController : Controller
    {
        public QooController()
        {

        }

        public ActionResult Index()
        {
            return Content("Qoo");
        }
    }
}