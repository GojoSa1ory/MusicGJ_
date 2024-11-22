using MusicG.Domain.User.Repository;

namespace MusicG.Domain.User.Usecases;

public class CreateUserUseCase
{

    private static UserRepository _repository;

    public CreateUserUseCase(UserRepository rep)
    {
        _repository = rep;
    }
    
    public static Task<ServiceResponse<bool>> invoke(UserModel newUser)
    {
        return _repository.CreateUser(newUser);
    }
}