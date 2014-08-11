using System;
namespace Ch05.Common.Services
{
    public interface ICustomerService
    {
        Ch05.Common.Models.Customer Get(int id);
    }
}
