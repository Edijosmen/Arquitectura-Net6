using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Aplication.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using AutoMapper;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Pacagroup.Ecommerce.Aplication.main
{ 
    public class CustomersApplication:ICustomersAplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomersApplication> _logger;
        public CustomersApplication(ICustomerDomain customerDomain, IMapper mapper, ILogger<CustomersApplication> logger)
        {
            _customerDomain = customerDomain;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronico
        public Response<bool> Insert(CustomersDto customerDto)
        {
            Response<bool> response = new();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);
                
                response.Data =  _customerDomain.Insert(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Existoso";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Update(CustomersDto customerDto)
        {
            Response<bool> response = new();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = _customerDomain.Update(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización  Existosa";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId)
        {
            Response<bool> response = new();
            try
            {
                response.Data = _customerDomain.Delete(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Existosa";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public Response<CustomersDto> Get(string customerId)
        {
            Response<CustomersDto> response = new();
            try
            {
                Customer customerByID = _customerDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDto>(customerByID);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                    _logger.LogInformation("consulta extosa!!");
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public Response<IEnumerable<CustomersDto>> GetAll()
        {
            Response<IEnumerable<CustomersDto>> response = new();
            try
            {
              

                IEnumerable<Customer> listCustomers = _customerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomersDto>>(listCustomers);
                if (response.Data !=null)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Existoso";

                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public ResponsePangination<IEnumerable<CustomersDto>> GetAllWithPagination(int PageNumber, int PageSize)
        {
            var response =  new ResponsePangination<IEnumerable<CustomersDto>>();
            try
            {
                var count = _customerDomain.Count();
                var customers = _customerDomain.GetAllWithPagination(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data !=null)
                {
                    response.PageNumber= PageNumber;
                    response.TotalPage = (int)Math.Ceiling(count / (double)PageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta paginada Exitosa!!";
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                response.Message= ex.Message;
            }
            return response;
        }
        #endregion

        #region Métodos ASíncronico
        public async Task<Response<bool>> InsertAsync(CustomersDto customerDto)
        {
            Response<bool> response = new();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = await _customerDomain.InsertAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Existoso";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomersDto customerDto)
        {
            Response<bool> response = new();
            try
            {
                Customer customer = _mapper.Map<Customer>(customerDto);

                response.Data = await _customerDomain.UpdateAsync(customer);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización  Existosa";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            Response<bool> response = new();
            try
            {
                response.Data = await _customerDomain.DeleteAsync(customerId);
                if (response.Data == true)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Existosa";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
         public async Task<Response<CustomersDto>> GetAsync(string customerId)
        {

            Response<CustomersDto> response = new();
            try
            {
                Customer customerByID = await _customerDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDto>(customerByID);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomersDto>>> GetAllAsync()
        {
            Response<IEnumerable<CustomersDto>> response = new();
            try
            {


                IEnumerable<Customer> listCustomers = await _customerDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomersDto>>(listCustomers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Existoso";
                }
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ResponsePangination<IEnumerable<CustomersDto>>> GetAllWithPaginationAsync(int PageNumber, int PageSize)
        {
            var response = new ResponsePangination<IEnumerable<CustomersDto>>();
            try
            {
                var count = await _customerDomain.CountAsync();
                var customers = await _customerDomain.GetAllWithPaginationAsync(PageNumber, PageSize);
                response.Data = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                if (response.Data != null)
                {
                    response.PageNumber = PageNumber;
                    response.TotalPage = (int)Math.Ceiling(count / (double)PageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta paginada Exitosa!!";
                }

            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.Message);
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion

    }
}