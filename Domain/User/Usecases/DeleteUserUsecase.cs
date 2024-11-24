using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class DeleteUserUsecase
{
    private IUserRepository _repository;

    public DeleteUserUsecase(IUserRepository repository)
    {
        _repository = repository;
    }

    public Task<bool> Invoke(int id)
    {
        return _repository.DeleteUser(id);
    }
}