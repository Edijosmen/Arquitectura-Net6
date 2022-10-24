using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Aplication.Interface
{
    public interface ICustomersAplication
    {
        #region Métodos Síncronico
        Response <bool> Insert(CustomersDto customerDto);
        Response<bool> Update(CustomersDto customerDto);
        Response<bool> Delete(string customerId);
        Response<CustomersDto> Get(string customerId);
        Response<IEnumerable<CustomersDto>> GetAll();
        ResponsePangination<IEnumerable<CustomersDto>> GetAllWithPagination(int PageNumber,int PageSize);
        #endregion

        #region Métodos ASíncronico
        Task<Response<bool>> InsertAsync(CustomersDto customerDto);
        Task<Response<bool>> UpdateAsync(CustomersDto customerDto);
        Task<Response<bool>> DeleteAsync(string customerId);
        Task<Response<CustomersDto>> GetAsync(string customerId);
        Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
        Task<ResponsePangination<IEnumerable<CustomersDto>>> GetAllWithPaginationAsync(int PageNumber, int PageSize);
        #endregion
    }
}
