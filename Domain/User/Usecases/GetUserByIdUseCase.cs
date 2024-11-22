using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class GetUserByIdUseCase
{
    private readonly UserRepository _repository;

    public GetUserByIdUseCase(UserRepository repository)
    {
        _repository = repository;
    }

    public Task<ServiceResponse<UserModel>> invoke(int id)
    {
        return _repository.GetUserById(id);
    }
}