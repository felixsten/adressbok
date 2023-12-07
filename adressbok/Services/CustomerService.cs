

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
        public void AddCustomerToList(CustomerModel customer)
        {
            try
            {
                // används för att lägga till ny person i listan, kollar också att samma email inte används
                if (!_customers.Any(x => x.Email == customer.Email))
                {
                    _customers.Add(customer);
                    // använder fileservice för att spara personen i json fil
                    _fileService.SaveContentToFile(JsonConvert.SerializeObject(_customers));
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
 
        

  
        }



        public IEnumerable<CustomerModel> GetCustomersFromList()
        {
            // gör json lista läsbar i menyn
            try
            {
                var content = _fileService.GetContentFromFile();
                if (!string.IsNullOrEmpty(content))
                {
                    _customers = JsonConvert.DeserializeObject<List<CustomerModel>>(content)!;
                }
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }

            // skickar tillbaks listan för att läsas
            return _customers;
        }


        
    }
}
