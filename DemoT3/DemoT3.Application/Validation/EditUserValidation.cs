using DemoT3.Contract.Constant;
using DemoT3.Contract.Requests;
using FluentValidation;

namespace DemoT3.Application.Validation
{
    public class EditUserValidation: AbstractValidator<EditUserRequest>
    {
        public EditUserValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Username"));
            RuleFor(x => x.Username).MaximumLength(50).WithMessage(string.Format(MessageError.Length, "Username"));

            RuleFor(x => x.Password).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Password"));

            RuleFor(x => x.Email).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Email"));
            RuleFor(x => x.FirstName).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "FirstName"));
            RuleFor(x => x.LastName).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "LastName"));
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "PhoneNumber"));
            RuleFor(x => x.Address).NotEmpty().WithMessage(string.Format(MessageError.NotEmpty, "Address"));

        }
    }
}
