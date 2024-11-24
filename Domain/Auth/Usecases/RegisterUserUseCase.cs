using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;

namespace MusicG.Domain.Auth.Usecases;

public class RegisterUserUseCase
{
    private readonly IAuthRepository _rep;

    public RegisterUserUseCase(IAuthRepository rep)
    {
        _rep = rep;
    }

    public Task<ServiceResponse<AuthModel, String>> Invoke(AuthModel reg)
    {
        return _rep.RegisterUser(reg);
    }
}