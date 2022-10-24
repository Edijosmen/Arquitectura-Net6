
namespace Pacagroup.Ecommerce.Infrastructure.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        ICustomerRepository Customer { get; }
        IUserRepository User { get; }
    }
}
