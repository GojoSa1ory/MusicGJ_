using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicG.Domain.User;
using MusicG.Domain.User.Repository;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.Exception.User;

namespace MusicG.Infrastructure.Repository;

public class UserRepositoryImpl : IUserRepository
{
    private readonly AppDatabaseContext _dao;
    private readonly IMapper _mapper;

    public UserRepositoryImpl(AppDatabaseContext dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public async Task<UserModel> GetUserByUsername(string username)
    {
        var user = await _dao.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Contains(username.ToLower()));

        if (user is null) throw new UserNotFoundException();

        return _mapper.Map<UserModel>(user);
    }

    public async Task<UserModel> GetUserById(int id)
    {
        var user = await _dao.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user is null) throw new UserNotFoundException();
        
        return _mapper.Map<UserModel>(user);
    }

    public async Task<bool> UpdateUser(UserToUpdateModel user, int userId)
    {
        var userFromBase = await _dao.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (userFromBase is null) throw new UserNotFoundException();

        userFromBase.Username = (user.Username == userFromBase.Username ? userFromBase.Username : user.Username) ??
                                throw new InvalidOperationException();
        userFromBase.Email = (user.Email == userFromBase.Email ? userFromBase.Email : user.Email) ??
                             throw new InvalidOperationException();
        if (user.Password?.Length >= 8 && !BCrypt.Net.BCrypt.Verify(user.Password, userFromBase.Password))
        {
            userFromBase.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        }

        await _dao.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteUser(int id)
    {
        var userFromBase = await _dao.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (userFromBase is null) throw new UserNotFoundException();

        _dao.Users.Remove(userFromBase);
        await _dao.SaveChangesAsync();

        return true;
    }
}