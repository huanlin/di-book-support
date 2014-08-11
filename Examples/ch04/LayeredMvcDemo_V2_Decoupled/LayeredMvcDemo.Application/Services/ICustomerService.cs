using System;
using System.Collections.Generic;
using LayeredMvcDemo.Domain.Models;

namespace LayeredMvcDemo.Application.Services
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        List<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}
