using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class GetUserByUsernameUseCase
{
    private readonly IUserRepository _repository;

    public GetUserByUsernameUseCase(IUserRepository repository)
    {
        _repository = repository;
    }


    public Task<UserModel> Invoke(string username)
    {
        return _repository.GetUserByUsername(username);
    }
}