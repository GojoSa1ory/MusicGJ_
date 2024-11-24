namespace MusicG.Domain.User.Repository;

public interface IUserRepository
{
    Task<UserModel> GetUserByUsername(string username);
    Task<UserModel> GetUserById(int id);
    Task<bool> UpdateUser(UserToUpdateModel user, int userId);
    Task<bool> DeleteUser(int id);
}