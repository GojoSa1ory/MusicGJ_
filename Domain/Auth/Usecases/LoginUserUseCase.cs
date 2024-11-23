using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;

namespace MusicG.Domain.Auth.Usecases;

public class LoginUserUseCase
{
    private readonly IAuthRepository _repository;

    public LoginUserUseCase(IAuthRepository repository)
    {
        _repository = repository;
    }

    public Task<ServiceResponse<AuthModel>> Invoke(AuthModel authModel)
    {
        return _repository.LoginUser(authModel);
    }
}