using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayeredMvcDemo.Application.Services;

namespace LayeredMvcDemo.Web.Controllers
{
    public class CustomerController : Controller
    {
        private CustomerService customerService = new CustomerService();

        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }

    }
}
