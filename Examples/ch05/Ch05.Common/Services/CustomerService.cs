using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ch05.Common.Models;

namespace Ch05.Common.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer Get(int id)
        {
            return new Customer()
            {
                Id =  id,
                Name = "Michael",
                Address = "Taipei, Taiwan"
            };
        }
    }
}