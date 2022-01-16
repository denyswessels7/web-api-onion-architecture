using OA.Core.Interfaces;
using OA.Core.Repository;
using OA.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var customers = await _customerRepo.GetAll();
            return customers;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _customerRepo.GetById(id);
            return customer;
        }

        public async Task<int> Add(Customer customer)
        {
            await _customerRepo.Add(customer);
            await _customerRepo.SaveChanges();
            return customer.Id;
        }
    }
}
