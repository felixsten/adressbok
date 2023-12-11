

using adressbok.Models;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;


namespace adressbok.Services
{
    public class MenuService
    {
        public readonly CustomerService _customerService = new CustomerService();
        /// <summary>
        /// listar alla menyalternativ
        /// </summary>
        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---MENU---");
                Console.WriteLine();
                Console.WriteLine("1. Register a person");
                Console.WriteLine("2. View all registered");
                Console.WriteLine("3. Search for specific person");
                Console.WriteLine("4. Delete a registered person");

                var option = Console.ReadLine();

                switch(option)
                {
                    // switch som tar dig till de olika alternativen på menyn
                    case "1":
                        ViewRegisterMenu();
                        break;
                    case "2":
                        ViewAllMenu();
                        break;
                    case "3":
                        ViewSearchMenu();
                        break;
                    case "4":
                        ViewDeleteMenu();
                        break;
                    // om inget av de 4 alternativen anges skrivs detta ut
                    default: Console.WriteLine("Invalid option. Choose 1 2 3 or 4.");
                        break;

                }

                Console.ReadKey();

            }
        }

        /// <summary>
        /// meny för att lägga till nya personer
        /// </summary>
        public void ViewRegisterMenu()
        {
            
        var customer = new CustomerModel();

        Console.Clear();
        Console.Write("Enter first name: ");
        customer.FirstName = Console.ReadLine()!;

        Console.Write("Enter last name: ");
        customer.LastName = Console.ReadLine()!;

        Console.Write("Enter phone number: ");
        customer.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter email address: ");
        customer.Email = Console.ReadLine()!;

        Console.Write("Enter home address: ");
        customer.Address = Console.ReadLine()!;

            // sparar informationen som anges till listan
        _customerService.AddCustomerToList(customer);
        }

        

        /// <summary>
        /// alternativ som visar alla användare i listan
        /// </summary>
        public void ViewAllMenu()
        {
            var customers = _customerService.GetCustomersFromList();

            Console.Clear();
            // foreach loop för att lista upp alla personer i listan
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Phone number: {customer.PhoneNumber}");
                Console.WriteLine($"Email address: {customer.Email}");
                Console.WriteLine($"Home address: {customer.Address}");
                Console.WriteLine("-----------------------------------");
            }


        }


        /// <summary>
        /// används för att söka efter specifik användare genom att skriva in email
        /// </summary>
        public void ViewSearchMenu()
        {
            Console.Clear();
            // anger vart json fil ligger och skapar variabel
            string jsonFilePath = @"C:\Projects\registered.json";
            // läser json fil och skapar variabel
            string jsonContent = File.ReadAllText(jsonFilePath);

            // listan görs läsbar för att hitta email adressen
            List<CustomerModel> customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonContent)!;

            // skriv in email av personen du vill hitta i listan
            Console.Write("Enter email to search for person: ");
            string searchEmail = Console.ReadLine()!;

            CustomerModel foundPerson = customers.Find(x => x.Email.Equals(searchEmail, StringComparison.OrdinalIgnoreCase))!;

            // om person finns i listan skrivs all deras information ut
            if (foundPerson != null)
            {
                Console.WriteLine($"Person found in list: {foundPerson.FirstName} {foundPerson.LastName}");
                Console.WriteLine($"Phone number: {foundPerson.PhoneNumber}");
                Console.WriteLine($"Email address: {foundPerson.Email}");
                Console.WriteLine($"Home address: {foundPerson.Address}");

            }
            else
            {
                Console.WriteLine("Person could not be found in list.");
            }

            

        }

        /// <summary>
        /// används för att ta bort en användare från listan genom att skriva deras email
        /// </summary>
        public void ViewDeleteMenu()
        {
            Console.Clear();
            // anger vart json fil ligger och skapar variabel
            string jsonFilePath = @"C:\Projects\registered.json";
            List<CustomerModel> customers;
            // läser json fil och skapar variabel
            string jsonContent = File.ReadAllText(jsonFilePath);

            // listan görs läsbar för att hitta email adressen
            customers = JsonConvert.DeserializeObject<List<CustomerModel>>(jsonContent)!;

            // skriv in email som tillhör personen du ska ta bort från listan
            Console.Write("Enter email address to delete person from the list: ");
            string searchEmail = Console.ReadLine()!;

            CustomerModel foundPerson = customers.Find(x => x.Email.Equals(searchEmail, StringComparison.OrdinalIgnoreCase))!;

            // om en person i listan har email adressen som skrevs in tas den bort från listan
            if (foundPerson != null)
            {
                Console.WriteLine($"Person found in list: {foundPerson.FirstName} {foundPerson.LastName}");

                // tar bort personen från listan och uppdaterar json fil 
                customers.Remove(foundPerson);
                string updatedJson = JsonConvert.SerializeObject(customers);
                File.WriteAllText(jsonFilePath, updatedJson);

                Console.WriteLine("Person has been deleted from the list.");
            }
            else
            {
                Console.WriteLine("Person could not be found in list.");
            }

            



        }


    }


}
