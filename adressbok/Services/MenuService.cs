

using adressbok.Models;
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
                Console.WriteLine("1. Register a customer");
                Console.WriteLine("2. View all customers");

                var option = Console.ReadLine();

                switch(option)
                {
                    case "1":
                        RegisterMenu();
                        break;
                    case "2":
                        ViewAllMenu();
                        break;

                }

                Console.ReadKey();

            }
        }
    

        private void RegisterMenu()
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

            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName} {customer.PhoneNumber} {customer.Email} {customer.Address}");
            }


        }


    }

}
