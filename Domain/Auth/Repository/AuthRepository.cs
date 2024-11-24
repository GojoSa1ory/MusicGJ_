using MusicG.Domain.Auth.Models;

namespace MusicG.Domain.Auth.Repository;

public interface IAuthRepository
{
    Task<ServiceResponse<AuthModel, String>> RegisterUser(AuthModel reqRegisterAuth);
    Task<ServiceResponse<AuthModel, String>> LoginUser(AuthModel requestLoginAuthDto);
    Task<AuthModel> VerifyUser(int userId);
}