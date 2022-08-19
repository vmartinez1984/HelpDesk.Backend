using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.Core.Validators
{

    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result;
            UserDtoOut user;

            user = validationContext.ObjectInstance as UserDtoOut;
            var _unitOfWorkBl = validationContext.GetService(typeof(IUnitOfWorkBl)) as IUnitOfWorkBl;
            if (user is null)
                result = _unitOfWorkBl.User.Exists(value.ToString()).Result;
            else
                result = _unitOfWorkBl.User.Exists(value.ToString(), user.Id).Result;
            if (result)
                return new ValidationResult("El correo ya existe");

            return ValidationResult.Success;
        }
    }
}