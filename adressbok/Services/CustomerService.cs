

using adressbok.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace adressbok.Services
{
    public class CustomerService
    {
        public readonly FileService _fileService = new FileService(@"C:\Projects\registered.json");
        public List<CustomerModel> _customers = [];
        public void AddCustomerToList(CustomerModel customer)
        {
            try
            {
                if (!_customers.Any(x => x.Email == customer.Email))
                {
                    _customers.Add(customer);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customers));
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
 
        

  
        }

        public void RemoveCustomerFromList(CustomerModel customer)
        {
            try
            {
                List<CustomerModel> _customers = JsonConvert.DeserializeObject<List<CustomerModel>>(@"C:\Projects\registered.json")!;

                _customers.Find(x => x.Email == customer.Email);

                if (customer != null)
                {
                    
                    _customers.Remove(customer);
                    string updatedJson = JsonConvert.SerializeObject(_customers);
                    File.WriteAllText(@"C:\Projects\registered.json", updatedJson);

                    Console.WriteLine("Person was deleted from list");
                }
                else
                {
                    Console.WriteLine("Person in list not found");
                }


            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

        }

        public IEnumerable<CustomerModel> GetCustomersFromList()
        {
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    _customers = JsonConvert.DeserializeObject<List<CustomerModel>>(content)!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            return _customers;
        }


        
    }
}
