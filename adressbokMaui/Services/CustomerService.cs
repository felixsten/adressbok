
using Newtonsoft.Json;
using adressbokMaui.Models;
using System.Diagnostics;

namespace adressbokMaui.Services
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

        public bool RemoveCustomerFromList(CustomerModel customer)
        {
            string jsonFilePath = @"C:\Projects\registered.json";
            List<CustomerModel> customers;

            string jsonContent = File.ReadAllText(jsonFilePath);

            customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonContent)!;

            if (!string.IsNullOrWhiteSpace(customer.Email))
            {
                var existingCustomer = _customers.FirstOrDefault(x => x.Email == customer.Email);
                if (existingCustomer != null)
                {
                    _customers.Remove(existingCustomer);
                    string updatedJson = JsonConvert.SerializeObject(customers);
                    File.WriteAllText(jsonFilePath, updatedJson);
                    return true;
                }
            }
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
