using MusicG.Domain;
using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.database.entity;
using MusicG.Infrastructure.Exception.Auth;
using MusicG.Infrastructure.Exception.User;
using MusicG.Infrastructure.Mapper;
namespace MusicG.Infrastructure.Repository;

public class AuthRepositoryImpl: IAuthRepository
{
    private readonly AppDatabaseContext _context;
    private readonly InfAuthMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthRepositoryImpl(AppDatabaseContext context, InfAuthMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<ServiceResponse<AuthModel>> RegisterUser(AuthModel reqRegisterAuth)
    {
        ServiceResponse<AuthModel> response = new();

        try
        {
            var existedUser = _context.Users.FirstOrDefault(u => u.Email == reqRegisterAuth.Email);

            if (existedUser != null)
                throw new UserAlreadyExistException();

            var newUser = _mapper.MapToEntity(reqRegisterAuth);

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            response.Data = _mapper.MapToDomain(newUser);
        }
        catch (System.Exception e)
        {
            response.Err = e.Message;
        }
        
        return response;
    }

    public async Task<ServiceResponse<AuthModel>> LoginUser(AuthModel requestLoginAuthDto)
    {
        ServiceResponse<AuthModel> res = new();

        try
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == requestLoginAuthDto.Username);

            if (user is null) 
                throw new UserNotFoundException();

            if (!BCrypt.Net.BCrypt.Verify(requestLoginAuthDto.Password, user.Password))
                throw new LoginFailedException();

            res.Data = _mapper.MapToDomain(user);
        }
        catch (System.Exception e)
        {
            res.Err = e.Message;
        }
        
        return res;
    }

    public async Task<AuthModel> VerifyUser(int userId)
    {
        UserEntity userFromDb = _context.Users.FirstOrDefault(u => u.Id == userId, defaultValue: null);

        if (userFromDb is null) throw new System.Exception("User not found");

        AuthModel authModel = new();
        authModel.Email = userFromDb.Email;
        authModel.Username = userFromDb.Username;
        authModel.Id = userFromDb.Id;

        return authModel;
    }
}