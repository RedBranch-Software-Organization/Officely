using RB.SharedKernel.MediatR.Command;

namespace Officely.UserService.Application.Commands.Register;

public class Command : ICommand
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Username { get; set; }
}
