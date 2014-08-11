using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayeredMvcDemo.Domain.Models;

namespace LayeredMvcDemo.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private SouthwindContext db = new SouthwindContext();

        public Customer GetCustomerById(int id)
        {
            var query = from t in db.Customers
                        where t.Id == id
                        select t;
            return query.FirstOrDefault();
        }

        public IEnumerable<Customer> GetCustomerList(Func<Customer, bool> filter)
        {
            var query = from t in db.Customers
                        select t;
            return query.Where(filter);
        }
    }
}
