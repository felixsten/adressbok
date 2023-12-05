

using adressbok.Models;
using System.Reflection.Metadata;

namespace adressbok.Services
{
    internal class CustomerAdd
    {
        public void Run()
        {
            var customer = new CustomerModel();

            customer.FirstName = "Felix";
            customer.LastName = "Sten";
            customer.PhoneNumber = "1234567890";
            customer.Email = "test@mail.com";
            customer.Address = "test";
        }
        
    }
}
