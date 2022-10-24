using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Aplication.Interface
{
    public interface IUserAplication
    {
        Response<UserDto> Authenticate(string userName, string password);
    }
}
