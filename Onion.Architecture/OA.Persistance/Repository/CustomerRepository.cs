using OA.Core.Repository;
using OA.Data;
using OA.Persistance.Context;
using OA.Persistance.Repository.Base;

namespace OA.Persistance.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(OADbContext dbContext) : base(dbContext)
        {

        }
    }
}
