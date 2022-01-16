using OA.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Core.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Customer>> GetAll();
        public Task<Customer> GetById(int id);
        public Task<int> Add(Customer customer);
    }
}
