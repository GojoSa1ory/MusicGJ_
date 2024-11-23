using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public interface IUserUseCaseInterface<T>
{
    Task<ServiceResponse<T>> Invoke(string username);
}

public class GetUserByUsernameUseCase: IUserUseCaseInterface<UserModel>
{
    private readonly IUserRepository _repository;

    public GetUserByUsernameUseCase(IUserRepository repository)
    {
        _repository = repository;
    }


    public async Task<ServiceResponse<UserModel>> Invoke(string username)
    {
        return await _repository.GetUserByUsername(username);
    }
}