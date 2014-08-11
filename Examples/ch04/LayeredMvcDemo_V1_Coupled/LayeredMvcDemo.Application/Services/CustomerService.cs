using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredMvcDemo.Domain.Models;
using LayeredMvcDemo.DataAccess;

namespace LayeredMvcDemo.Application.Services
{
    public class CustomerService
    {
        private CustomerRepository repository = new CustomerRepository();

        public Customer GetCustomerById(int id)
        {
            return repository.GetCustomerById(id);
        }

        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return repository.GetCustomerList(filter).ToList();
        }
    }
}
