using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Aplication.Interface;

namespace Pacagroup.Ecommerce.Service.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CustomersController : Controller
    {
        private readonly ICustomersAplication _customersAplication;

        public CustomersController(ICustomersAplication customersAplication)
        {
            _customersAplication = customersAplication;

        }
        /// <summary>
        ///    Gets all activities.
        /// </summary>
        /// <param name="customersDto">fdfdfdfdf</param>
        /// <returns></returns>
        #region sincronos

        [HttpPost]
        public IActionResult Insert([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersAplication.Insert(customersDto);
            if (response.IsSuccess == true)
                return Ok(response);
            return BadRequest(response.Message);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = _customersAplication.Update(customersDto);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpDelete("{customersId}")]
        public IActionResult Delete(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersAplication.Delete(customerId);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpGet]
        public IActionResult Get(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = _customersAplication.Get(customerId);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _customersAplication.GetAll();
            if (response.IsSuccess == true)
                return Ok(response);
            return BadRequest(response.Message);
        }
        [HttpGet]
        public IActionResult GetAllWithPaginations([FromQuery] int pageNumber,int pageSize)
        {
            var response = _customersAplication.GetAllWithPagination(pageNumber, pageSize);
            if (response.IsSuccess == true)
                return Ok(response);
            return BadRequest(response.Message);
        }

        #endregion

        #region Asincronos
        /// <summary>
        /// afdfdfadf
        /// </summary>
        /// <param name="customersDto">dfadfadfadff</param>
        /// <returns></returns>
        [HttpPost("Async")]
        public async Task<IActionResult> InsertAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersAplication.InsertAsync(customersDto);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpPut("Async")]
        public async Task<IActionResult> UpdateAsync([FromBody] CustomersDto customersDto)
        {
            if (customersDto == null)
            {
                return BadRequest();
            }
            var response = await _customersAplication.UpdateAsync(customersDto);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpDelete("Async/{customersId}")]
        public async Task<IActionResult> DeleteAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersAplication.DeleteAsync(customerId);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpGet("Async")]
        public async Task<IActionResult> GetAsync(string customerId)
        {
            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest();
            }
            var response = await _customersAplication.GetAsync(customerId);
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        [HttpGet("Async")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _customersAplication.GetAllAsync();
            if (response.IsSuccess == true)
                return Ok(response.Data);
            return BadRequest(response.Message);
        }
        #endregion
    }
}
