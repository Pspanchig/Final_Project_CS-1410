using NUnit.Framework;
using System;

namespace ProjectTests
{
    [TestFixture]
    public class Company_userTests
    {
        [Test]
        public void AddEmployee_AddsEmployeeToList()
        {
            Company_user companyUser = new Company_user();
            Company_user employee = new Company_user();

            companyUser.AddEmployee(employee);

            Assert.Contains(employee, companyUser.ListOfEmployees);
        }

        [Test]
        public void AddCustomer_AddsCustomerToList()
        {
            Company_user companyUser = new Company_user();
            Normal_Customer customer = new Normal_Customer();

            companyUser.AddCustomer(customer);

            Assert.Contains(customer, companyUser.ListOfCustomers);
        }

        [Test]
        public void DisplayErrors_ValidPassword_ReturnsTrue()
        {
            string validPassword = "Abc123"; 
            PasswordC passwordChecker = new PasswordC(validPassword);

            bool result = passwordChecker.DisplayErrors();

            Assert.IsTrue(result);
        }

        [Test]
        public void DisplayErrors_PasswordLessThan6Characters_ReturnsFalse()
        {
            string invalidPassword = "Abc12";
            PasswordC passwordChecker = new PasswordC(invalidPassword);

            bool result = passwordChecker.DisplayErrors();

            Assert.IsFalse(result);
        }

        [Test]
        public void DisplayErrors_PasswordGreaterThan20Characters_ReturnsFalse()
        {
            string invalidPassword = "Abc123Abc123Abc123Abc1"; 
            PasswordC passwordChecker = new PasswordC(invalidPassword);

            bool result = passwordChecker.DisplayErrors();

            Assert.IsFalse(result);
        }


    }
}
