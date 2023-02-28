using FastEndpoints;
using FluentValidation;

namespace GLFoundation.Identity.Api.Features.CreateToken
{
    public class CreateTokenValidator : Validator<CreateTokenRequest>
    {
        public CreateTokenValidator()
        {
            RuleFor(x => x.EmailId).NotEmpty().WithMessage("EmailId cannot be empty");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}
