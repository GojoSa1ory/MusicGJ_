namespace MusicG.Domain.User.Repository;

public interface IUserRepository
{
    Task<ServiceResponse<UserModel>> GetUserByUsername(string username);
    Task<ServiceResponse<UserModel>> GetUserById(int id);
    Task<ServiceResponse<bool>> CreateUser(UserModel newUser);
}