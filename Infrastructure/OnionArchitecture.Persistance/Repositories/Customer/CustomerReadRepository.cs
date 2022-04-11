using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(OnionArchitectureDbContext context) : base(context)
        {

        }
    }
}
