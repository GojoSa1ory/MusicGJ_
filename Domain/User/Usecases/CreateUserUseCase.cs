using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class CreateUserUseCase
{

    private static IUserRepository _repository;

    public CreateUserUseCase(IUserRepository rep)
    {
        _repository = rep;
    }
    
    public static Task<ServiceResponse<bool>> Invoke(UserModel newUser)
    {
        return _repository.CreateUser(newUser);
    }
}