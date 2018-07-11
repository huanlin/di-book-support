using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Ch05.Common.Services;

namespace Ex02.DependencyResolver.Microsoft.Controllers
{
    public class ValuesController : ApiController
    {
        private ICustomerService _customerService;

        public ValuesController()
        {
            _customerService = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(CustomerService)) as ICustomerService;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {            
            var customer = _customerService.Get(1);
            return new string[] { customer.Id.ToString(), customer.Name };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
