using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using OA.Api.Controllers;
using OA.Core.Interfaces;
using OA.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace OA.Api.Tests
{
    public class CustomerControllerTests
    {
        //Following a simple three step tests system(AAA):
        //1.Arrange
        //2.Act
        //3.Assert

        [Theory]
        [InlineData(5)]
        public async Task GetAllCustomers(int count)
        {
            //Arrange
            var dummyCustomers = GetCustomers(count);
            var dataStore = A.Fake<ICustomerService>();
            A.CallTo(() => dataStore.GetAll()).Returns(Task.FromResult(dummyCustomers));

            //Act 
            var controller = new CustomerController(dataStore);
            var actionResults = await controller.Get();

            //Assert
            var result = actionResults as OkObjectResult;
            var resultCustomers = result.Value as IEnumerable<Customer>;
            Assert.Equal(count, resultCustomers.Count());
        }

        [Theory]
        [InlineData(1,2)]
        public async Task GetCustomerById(int id,int count)
        {
            var dummyCustomers = GetCustomers(count);
            dummyCustomers.ElementAt(0).Id = 1;
            var dataStore = A.Fake<ICustomerService>();
            A.CallTo(() => dataStore.GetById(id)).Returns(Task.FromResult(dummyCustomers.ElementAt(0)));

            var controller = new CustomerController(dataStore);
            var actionResults = await controller.GetById(id);

            var result = actionResults as OkObjectResult;
            var customer = result.Value as Customer;
            Assert.NotNull(customer);
            Assert.Equal(id, customer.Id);
        }

        [Theory]
        [InlineData(61,2)]
        public async Task Return404IfCustomerNotFound(int id,int count)
        {
            var dummyCustomers = GetCustomers(count);
            dummyCustomers.ElementAt(0).Id = 1;
            var dataStore = A.Fake<ICustomerService>();
            A.CallTo(() => dataStore.GetById(id)).Returns(Task.FromResult(dummyCustomers.Where(e => e.Id == id).FirstOrDefault()));

            var controller = new CustomerController(dataStore);
            var actionResults = await controller.GetById(id);

            var result = actionResults as NotFoundResult;
            Assert.NotNull(result);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async Task AddCustomer()
        {
            //Arrange
            int expectedId = 100;
            var customer = new Customer { FirstName = "Name", LastName="Surname" };
            var dataStore = A.Fake<ICustomerService>();
            A.CallTo(() => dataStore.Add(customer)).Returns(Task.FromResult(expectedId));

            //Act 
            var controller = new CustomerController(dataStore);
            var actionResults = await controller.Post(customer);

            //Assert
            var result = actionResults as CreatedResult;
            Assert.NotNull(result);
            Assert.Equal(expectedId, (int)result.Value);
        }

        public IEnumerable<Customer> GetCustomers(int count)
        {
            var dummyCustomers = A.CollectionOfDummy<Customer>(count).AsEnumerable();
            return dummyCustomers;
        }
    }
}
