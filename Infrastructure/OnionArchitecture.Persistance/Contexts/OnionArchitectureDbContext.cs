using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Contexts
{
    public class OnionArchitectureDbContext : DbContext
    {
        public OnionArchitectureDbContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Customer> Customers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var items = ChangeTracker.Entries<BaseEntity>();
            foreach (var item in items)
            {
                _ = item.State switch
                {
                    EntityState.Added => item.Entity.CreatedDate = DateTime.UtcNow,
                    //EntityState.Detached => throw new NotImplementedException(),
                    //EntityState.Unchanged => throw new NotImplementedException(),
                    //EntityState.Deleted => throw new NotImplementedException(),
                    //EntityState.Modified => throw new NotImplementedException(),
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
