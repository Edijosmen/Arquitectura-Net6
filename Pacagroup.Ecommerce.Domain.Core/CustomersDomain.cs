
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Infrastructure.Interface;

namespace Pacagroup.Ecommerce.Domain.Core
{
    public class CustomersDomain:ICustomerDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int Count()
        {
          return _unitOfWork.Customer.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Customer.CountAsync();
        }

        public bool Delete(string customerId)
        {
            return  _unitOfWork.Customer.Delete(customerId);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customer.DeleteAsync(customerId);
        }

        public Customer Get(string customerId)
        {
            return _unitOfWork.Customer.Get(customerId);
        }

        public IEnumerable<Customer> GetAll()
        {
           return _unitOfWork.Customer.GetAll();
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
           return await _unitOfWork.Customer.GetAllAsync();
        }

        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.Customer.GetAllWithPagination(pageNumber, pageSize);
        }

        public async Task<Customer> GetAsync(string customerId)
        {
            return await _unitOfWork.Customer.GetAsync(customerId);
        }

        public bool Insert(Customer customer)
        {
            return _unitOfWork.Customer.Insert(customer);
        }

        public async Task<bool> InsertAsync(Customer customer)
        {
            return await _unitOfWork.Customer.InsertAsync(customer);
        }

        public bool Update(Customer customer)
        {
            return  _unitOfWork.Customer.Update(customer);
        }

        public async Task<bool> UpdateAsync(Customer customer)
        {
            return await _unitOfWork.Customer.UpdateAsync(customer); 
        }

        async Task<IEnumerable<Customer>> ICustomerDomain.GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customer.GetAllWithPaginationAsync(pageNumber, pageSize);
        }
    }
}