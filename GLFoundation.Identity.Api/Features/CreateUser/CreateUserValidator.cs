using FastEndpoints;
using FluentValidation;

namespace GLFoundation.Identity.Api.Features.CreateUser
{
    public class CreateUserValidator : Validator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.EmailId).NotEmpty().WithMessage("EmailId cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
