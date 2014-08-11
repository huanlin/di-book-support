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
        private readonly ICustomerService customerService;

        public CustomerController()
        {
            this.customerService = new CustomerService();
        }

        public CustomerController(ICustomerService service)
        {
            this.customerService = service;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var customers = customerService.GetCustomerList(cust => cust.Id < 4);
            return View(customers);
        }
    }
}
