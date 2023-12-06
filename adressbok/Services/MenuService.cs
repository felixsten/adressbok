

using adressbok.Models;
using System;
using System.Reflection.Metadata;

namespace adressbok.Services
{
    internal class MenuService
    {
        private readonly CustomerService _customerService = new CustomerService();

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
                    default: Console.WriteLine("Invalid option. Choose 1 2 3 or 4.");
                        break;

                }

                Console.ReadKey();

            }
        }
    

        private void ViewRegisterMenu()
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

        _customerService.AddCustomerToList(customer);
        }

        


        private void ViewAllMenu()
        {
            var customers = _customerService.GetCustomersFromList();

            Console.Clear();

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Phone number: {customer.PhoneNumber}");
                Console.WriteLine($"Email address: {customer.Email}");
                Console.WriteLine($"Home address: {customer.Address}");
                Console.WriteLine("-----------------------------------");
            }


        }


        private void ViewSearchMenu()
        {
            var customers = _customerService.GetCustomersFromList();
            


            Console.Clear();
            Console.Write("Enter email address to search for person: ");
            string searchEmail = Console.ReadLine()!;

            CustomerModel customer = customers.Find(p => p.Email.Equals(searchEmail, StringComparison.OrdinalIgnoreCase))!;

            if (customer != null)
            {
                Console.WriteLine($"Person found: {customer.FirstName} {customer.LastName}");
                Console.WriteLine($"Phone number: {customer.PhoneNumber}");
                Console.WriteLine($"Email address: {customer.Email}");
                Console.WriteLine($"Home address: {customer.Address}");
            }
            else
            {
                Console.WriteLine("Could not find any person with this email in the list.");
            }

        }

        private void ViewDeleteMenu()
        {
            var customers = _customerService.GetCustomersFromList();



            Console.Clear();
            Console.Write("Enter email address to delete person from the list: ");
            string searchEmail = Console.ReadLine()!;

            CustomerModel customer = customers.Find(p => p.Email.Equals(searchEmail, StringComparison.OrdinalIgnoreCase))!;

            if (customer != null)
            {
                Console.WriteLine($"Person found: {customer.FirstName} {customer.LastName}");

                customers.Remove(customer);
                Console.WriteLine("Person has been deleted from the list.");
                
            }
            else
            {
                Console.WriteLine("Could not find any person with this email to delete from the list.");
            }

        }


    }


}
