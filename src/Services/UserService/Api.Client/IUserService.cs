using Officely.UserService.Api.Client.Models.SignUp;
using Refit;

namespace Officely.UserService.Api.Client;

public interface IUserService
{
    [Post("/signup")]
    Task<SignUpResponseDto> SignUp([Body] SignUpRequestDto requestDto);
}
