using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ch05.Common.Models;
using Ch05.Common.Services;

namespace Ex02.DependencyResolver.AutofacDemo.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public Customer Get(int id)
        {
            var customer = _customerService.Get(id);
            customer.UpdateTime = DateTime.Now;

            return customer;
        }
    }
}
