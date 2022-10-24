using Pacagroup.Ecommerce.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICustomerRepository Customer { get; }

        public IUserRepository User { get; }

        public UnitOfWork( ICustomerRepository customer,IUserRepository user)
        {
            Customer = customer;
            User = user;
        }
        public void Dispose()
        {
            System.GC.SuppressFinalize(this);
        }
    }
}
