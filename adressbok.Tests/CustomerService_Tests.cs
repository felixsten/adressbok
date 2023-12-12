
using adressbok.Services;
using adressbok.Models;

namespace adressbok.Tests
{
    public class CustomerService_Tests
    {
        [Fact]
        public void AddToListShould_AddOneCustomerToCustomerList_ThenReturnTrue()
        {
            // Arrange
            CustomerModel customer = new CustomerModel { FirstName = "Testname", LastName = "Testname", PhoneNumber = "111111", Email = "test@mail.com", Address = "Testaddress" };
            CustomerService customerService = new CustomerService();

            // Act
            var result = customerService.AddCustomerToList(customer);

            // Assert
            Assert.True(result);
        }



        [Fact]

        public void GetAllFromListShould_GetAllCustomersInCustomerList_ThenReturnList()
        {
            // Arrange
            CustomerModel customer = new CustomerModel { FirstName = "Testname", LastName = "Testname", PhoneNumber = "111111", Email = "test@mail.com", Address = "Testaddress" };
            CustomerService customerService = new CustomerService();
            customerService.AddCustomerToList(customer);

            // Act
            IEnumerable<CustomerModel> result = customerService.GetCustomersFromList();

            // Assert
            Assert.NotNull(result);
            CustomerModel returned_customer = result.FirstOrDefault()!;
            Assert.NotNull(returned_customer);
            Assert.Equal(customer.FirstName, returned_customer.FirstName);
        }
    }

    
}
