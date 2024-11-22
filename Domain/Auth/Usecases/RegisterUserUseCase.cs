using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;

namespace MusicG.Domain.Auth.Usecases;

public class RegisterUserUseCase
{
    private readonly AuthRepository _rep;

    public RegisterUserUseCase(AuthRepository rep)
    {
        _rep = rep;
    }

    public Task<ServiceResponse<AuthModel>> invoke(AuthModel reg)
    {
        return _rep.RegisterUser(reg);
    }
}