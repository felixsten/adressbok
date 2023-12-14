

using adressbokMaui.Models;
using adressbokMaui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace adressbokMaui.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly CustomerService _customerService;


        public MainViewModel(CustomerService customerService)
        {
            _customerService = customerService;
            UpdateCustomerList();

        }

        [ObservableProperty]
        private CustomerModel _registrationForm = new();

        [ObservableProperty]
        private ObservableCollection<CustomerModel> _customerList = [];

        [RelayCommand]
        public void AddContactToList()
        {
            if (RegistrationForm != null && !string.IsNullOrWhiteSpace(RegistrationForm.Email))
            {
                var result = _customerService.AddCustomerToList(RegistrationForm);
                if (result)
                {
                    UpdateCustomerList();
                    RegistrationForm = new();
                }

            }
        }

        [RelayCommand]
        public void RemoveContactFromList(CustomerModel customer)
        {
            if (customer != null)
            {
                var result = _customerService.RemoveCustomerFromList(customer);
                if (result)
                {
                    UpdateCustomerList();
                }
            }
        }

        public void UpdateCustomerList()
        {
            CustomerList = new ObservableCollection<CustomerModel>(_customerService._customers.Select(customer => customer).ToList());
        }

    }
}
