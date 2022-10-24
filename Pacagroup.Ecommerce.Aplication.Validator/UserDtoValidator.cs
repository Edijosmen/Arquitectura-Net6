using FluentValidation;
using Pacagroup.Ecommerce.Aplication.Dto;

namespace Pacagroup.Ecommerce.Aplication.Validator
{
    public class UserDtoValidator:AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(u=>u.UserName).NotNull().NotEmpty();
            RuleFor(u=>u.Password).NotNull().NotEmpty();
        }
    }
}