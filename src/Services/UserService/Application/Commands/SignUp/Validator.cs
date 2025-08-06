using FluentValidation;

namespace Officely.UserService.Application.Commands.SignUp;

public class Validator : AbstractValidator<Command>
{
    public Validator()
    {
        //ToDo: Use validation from Domain Entities
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
    }
}
