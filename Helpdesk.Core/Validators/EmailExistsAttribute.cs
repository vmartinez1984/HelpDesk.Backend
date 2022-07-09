using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.Core.Validators
{
    
    public class EmailExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            bool result;

            var _unitOfWorkBl = validationContext.GetService(typeof(IUnitOfWorkBl)) as IUnitOfWorkBl;

            result = _unitOfWorkBl.User.Exists(value.ToString()).Result;
            if (result)
                return new ValidationResult("El correo ya existe");

            return ValidationResult.Success;
        }
    }
}