using System;
using System.Collections.Generic;
using LayeredMvcDemo.Domain.Models;

namespace LayeredMvcDemo.DataAccess
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomerList(Func<Customer, bool> filter);
    }
}
