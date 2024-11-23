using MusicG.Domain.Auth.Models;

namespace MusicG.Domain.Auth.Repository;

public interface IAuthRepository
{
    Task<ServiceResponse<AuthModel>> RegisterUser(AuthModel reqRegisterAuth);
    Task<ServiceResponse<AuthModel>> LoginUser(AuthModel requestLoginAuthDto);
    Task<AuthModel> VerifyUser(int userId);
}