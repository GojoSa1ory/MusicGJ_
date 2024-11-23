using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class GetUserByIdUseCase
{
    private readonly IUserRepository _repository;

    public GetUserByIdUseCase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<ServiceResponse<UserModel>> Invoke(int id)
    {
        return _repository.GetUserById(id);
    }
}