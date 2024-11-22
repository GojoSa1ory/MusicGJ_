namespace MusicG.Domain.User.Repository;

public interface UserRepository
{
    Task<ServiceResponse<UserModel>> GetUserByUsername(string username);
    Task<ServiceResponse<UserModel>> GetUserById(int id);
    Task<ServiceResponse<bool>> CreateUser(UserModel newUser);
}