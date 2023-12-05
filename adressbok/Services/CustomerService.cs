

using adressbok.Models;
using System.Reflection.Metadata;

namespace adressbok.Services
{
    public class CustomerService
    {
        private readonly List<CustomerModel> _customers = [];
        public void AddCustomerToList(CustomerModel customer)
        {
            if (! _customers.Any(x => x.Email == customer.Email))
                _customers.Add(customer);

  
        }

        public List<CustomerModel> GetCustomersFromList()
        {
            return _customers;
        }

        
    }
}
