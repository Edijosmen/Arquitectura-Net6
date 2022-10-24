using AutoMapper;
using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Aplication.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using Pacagroup.Ecommerce.Aplication.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Aplication.main
{
    public class UserAplication : IUserAplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDtoValidator _validationRules;
        public UserAplication(IUserDomain userDomain, IMapper mapper, UserDtoValidator validationRules)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public Response<UserDto> Authenticate(string userName, string password)
        {
            var response = new Response<UserDto>();
            var validation = _validationRules.Validate(new UserDto() { UserName = userName, Password = password });
            if(!validation.IsValid)
            {
                response.Message = "Errores de Validación";
                response.Erros = validation.Errors;
                return response;
            }

            try
            {
                var user = _userDomain.Authenticate(userName, password);
                response.Data = _mapper.Map<UserDto>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación Exitosa!!";
            }
            catch (InvalidOperationException )
            {
                response.IsSuccess = true;
                response.Message = "Usuario no existe";
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
            }
            return response;
        }
    }
}
