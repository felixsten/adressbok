

using adressbok.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace adressbok.Services
{
    public class CustomerService
    {
        // lista med personer skapas
        public readonly FileService _fileService = new FileService(@"C:\Projects\registered.json");
        public List<CustomerModel> _customers = [];
        /// <summary>
        /// lägger till användare i lista
        /// </summary>
        /// <param name="customer"></param>
        public bool AddCustomerToList(CustomerModel customer)
        {
            try
            {
                if (!_customers.Any(x => x.Email == customer.Email))
                {
                    _customers.Add(customer);
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customers));
                    return true;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return false;   
 
        

  
        }


        /// <summary>
        /// hämtar alla användare i listan
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetCustomersFromList()
        {
            // gör json lista läsbar i menyn
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    _customers = JsonConvert.DeserializeObject<List<CustomerModel>>(content)!;
                    return _customers;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return null!;
            
            
        }


        
    }
}
