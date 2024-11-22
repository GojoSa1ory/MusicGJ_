using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;

namespace MusicG.Domain.Auth.Usecases;

public class LoginUserUseCase
{
    private readonly AuthRepository _repository;

    public LoginUserUseCase(AuthRepository repository)
    {
        _repository = repository;
    }

    public Task<ServiceResponse<AuthModel>> invoke(AuthModel authModel)
    {
        return _repository.LoginUser(authModel);
    }
}