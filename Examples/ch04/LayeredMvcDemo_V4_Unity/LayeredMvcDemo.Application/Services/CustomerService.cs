using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredMvcDemo.Domain.Models;
using LayeredMvcDemo.DataAccess;

namespace LayeredMvcDemo.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SouthwindContext db;

        public CustomerService(SouthwindContext dbContext)
        {
            // 呼叫端有注入 DbContext 物件，就用對方提供的。
            this.db = dbContext;
        }

        public Customer GetCustomerById(int id)
        {
            return db.Customers.Find(id);
        }

        public List<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            return db.Customers.Where(filter).ToList();
        }
    }
}
