using AutoMapper;
using MusicG.Domain;
using MusicG.Domain.User;
using MusicG.Domain.User.Repository;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.Exception.User;

namespace MusicG.Infrastructure.Repository;

public class UserRepositoryImpl: IUserRepository
{
    private readonly AppDatabaseContext _dao;
    private readonly IMapper _mapper;
    
    public UserRepositoryImpl(AppDatabaseContext dao, IMapper mapper)
    {
        _dao = dao;
        _mapper = mapper;
    }

    public Task<ServiceResponse<UserModel>> GetUserByUsername(string username)
    {
        ServiceResponse<UserModel> response = new();

        try
        {
            var user = _dao.Users.FirstOrDefault(u => u.Username == username);

            if (user is null) throw new UserNotFoundException();
            
            response.Data = _mapper.Map<UserModel>(user);

        }
        catch (System.Exception e)
        {
            response.Err = e.Message;
        }
        
        return Task.FromResult(response);
    }

    public async Task<ServiceResponse<UserModel>> GetUserById(int id)
    {
        ServiceResponse<UserModel> response = new();

        try
        {
            var user = _dao.Users.FirstOrDefault(u => u.Id == id);

            if (user is null) throw new UserNotFoundException();
            
            response.Data = _mapper.Map<UserModel>(user);

        }
        catch (System.Exception e)
        {
            response.Err = e.Message;
        }
        

        return response;
    }

    public Task<ServiceResponse<bool>> CreateUser(UserModel newUser)
    {
        throw new NotImplementedException();
    }
}