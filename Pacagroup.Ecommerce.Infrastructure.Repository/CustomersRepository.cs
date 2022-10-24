using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Infrastructure.Interface;
using Dapper;
using System.Data;
using System.Collections;
using Pacagroup.Ecommerce.Infrastructura.Data;

namespace Pacagroup.Ecommerce.Infrastructure.Repository
{
    public class CustomersRepository:ICustomerRepository
    {
        private readonly DapperContext _context;
        public CustomersRepository(DapperContext dapperContext)
        {
            _context = dapperContext;
        }

        #region Métodos síncronicos
        public bool Insert(Customer customer)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersInsert";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID",customer.CustomerId);
                paramerts.Add("CompanyName", customer.CompanyName);
                paramerts.Add("ContactName", customer.ContactName);
                paramerts.Add("ContactTitle", customer.ContactTitle);
                paramerts.Add("Address", customer.Addres);
                paramerts.Add("City", customer.City);
                paramerts.Add("Region", customer.Region);
                paramerts.Add("PostalCode", customer.PostalCode);
                paramerts.Add("Country", customer.Country);
                paramerts.Add("Phone",customer.Phone);
                paramerts.Add("Fax",customer.Fax);

                var result = connection.Execute(query,paramerts,commandType:CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Update(Customer customer)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersUpdate";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customer.CustomerId);
                paramerts.Add("CompanyName", customer.CompanyName);
                paramerts.Add("ContactName", customer.ContactName);
                paramerts.Add("ContactTitle", customer.ContactTitle);
                paramerts.Add("Address", customer.Addres);
                paramerts.Add("City", customer.City);
                paramerts.Add("Region", customer.Region);
                paramerts.Add("PostalCode", customer.PostalCode);
                paramerts.Add("Country", customer.Country);
                paramerts.Add("Phone", customer.Phone);
                paramerts.Add("Fax", customer.Fax);

                var result = connection.Execute(query, paramerts, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public bool Delete(string customerId)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersDelete";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customerId);
                

                var result = connection.Execute(query, paramerts, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public Customer Get(string customerId)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersGetByID";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customerId);


                var customer = connection.QuerySingle<Customer>(query, paramerts, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public IEnumerable<Customer> GetAll()
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersList";
               


                var customers = connection.Query<Customer>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public IEnumerable<Customer> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using(var connection = _context.CreateConnectionString())
            {
                var query = "CustomersListWithPagination";
                var parameters = new DynamicParameters();
                parameters.Add("PageNumber",pageNumber);
                parameters.Add("PageSize", pageSize);
                var customers = connection.Query<Customer>(query, param:parameters, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public int Count()
        {
            using (var connection= _context.CreateConnectionString())
            {
                var query = "Select Count(*) from Customers";
                var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
                return count;
            }
        }
        #endregion

        #region Métodos Asíncronicos
        public async Task<bool> InsertAsync(Customer customer)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersInsert";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customer.CustomerId);
                paramerts.Add("CompanyName", customer.CompanyName);
                paramerts.Add("ContactName", customer.ContactName);
                paramerts.Add("ContactTitle", customer.ContactTitle);
                paramerts.Add("Address", customer.Addres);
                paramerts.Add("City", customer.City);
                paramerts.Add("Region", customer.Region);
                paramerts.Add("PostalCode", customer.PostalCode);
                paramerts.Add("Country", customer.Country);
                paramerts.Add("Phone", customer.Phone);
                paramerts.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, paramerts, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> UpdateAsync(Customer customer)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersUpdate";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customer.CustomerId);
                paramerts.Add("CompanyName", customer.CompanyName);
                paramerts.Add("ContactName", customer.ContactName);
                paramerts.Add("ContactTitle", customer.ContactTitle);
                paramerts.Add("Address", customer.Addres);
                paramerts.Add("City", customer.City);
                paramerts.Add("Region", customer.Region);
                paramerts.Add("PostalCode", customer.PostalCode);
                paramerts.Add("Country", customer.Country);
                paramerts.Add("Phone", customer.Phone);
                paramerts.Add("Fax", customer.Fax);

                var result = await connection.ExecuteAsync(query, paramerts, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<bool> DeleteAsync(string customerId)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersDelete";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customerId);


                var result = await connection.ExecuteAsync(query, paramerts, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }
        public async Task<Customer> GetAsync(string customerId)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersGetByID";
                var paramerts = new DynamicParameters();
                paramerts.Add("CustomerID", customerId);


                var customer = await connection.QuerySingleAsync<Customer>(query, paramerts, commandType: CommandType.StoredProcedure);
                return customer;
            }
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersList";



                var customers = await connection.QueryAsync<Customer>(query, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }

       

        public async Task<IEnumerable<Customer>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "CustomersListWithPagination";
                var parameters = new DynamicParameters();
                parameters.Add("PageNumber", pageNumber);
                parameters.Add("PageSize", pageSize);
                var customers = await connection.QueryAsync<Customer>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return customers;
            }
        }
        public async Task<int> CountAsync()
        {
            using (var connection = _context.CreateConnectionString())
            {
                var query = "Select Count(*) from Customers";
                int count =  await connection.ExecuteScalarAsync<int>(query,commandType:CommandType.Text);
                return count;
            }
        }
        #endregion
    }
}