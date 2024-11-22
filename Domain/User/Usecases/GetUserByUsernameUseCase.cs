using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public interface UserUseCaseInterface<T>
{
    Task<ServiceResponse<T>> invoke(string username);
}

public class GetUserByUsernameUseCase: UserUseCaseInterface<UserModel>
{
    private readonly UserRepository _repository;

    public GetUserByUsernameUseCase(UserRepository repository)
    {
        _repository = repository;
    }


    public async Task<ServiceResponse<UserModel>> invoke(string username)
    {
        return await _repository.GetUserByUsername(username);
    }
}