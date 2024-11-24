using Microsoft.EntityFrameworkCore;
using MusicG.Domain;
using MusicG.Domain.Auth.Models;
using MusicG.Domain.Auth.Repository;
using MusicG.Infrastructure.database;
using MusicG.Infrastructure.Exception.Auth;
using MusicG.Infrastructure.Exception.User;
using MusicG.Infrastructure.Mapper;
namespace MusicG.Infrastructure.Repository;

public class AuthRepositoryImpl: IAuthRepository
{
    private readonly AppDatabaseContext _context;
    private readonly InfAuthMapper _mapper;

    public AuthRepositoryImpl(AppDatabaseContext context, InfAuthMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<AuthModel, String>> RegisterUser(AuthModel reqRegisterAuth)
    {
        try
        {
            var existedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == reqRegisterAuth.Email);

            if (existedUser != null)
                throw new UserAlreadyExistException();

            var newUser = _mapper.MapToEntity(reqRegisterAuth);

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return ServiceResponse<AuthModel, string>.Success(_mapper.MapToDomain(newUser));
        }
        catch (System.Exception e)
        {
            return ServiceResponse<AuthModel, string>.Failure(e.Message);
        }
        
    }

    public async Task<ServiceResponse<AuthModel, String>> LoginUser(AuthModel requestLoginAuthDto)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == requestLoginAuthDto.Username);

            if (user is null) 
                throw new UserNotFoundException();

            if (!BCrypt.Net.BCrypt.Verify(requestLoginAuthDto.Password, user.Password))
                throw new LoginFailedException();

            return ServiceResponse<AuthModel, string>.Success(_mapper.MapToDomain(user));
        }
        catch (System.Exception e)
        {
            return ServiceResponse<AuthModel, string>.Failure(e.Message);
        }
    }

    public async Task<AuthModel> VerifyUser(int userId)
    {
        var userFromDb = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (userFromDb is null) throw new System.Exception("User not found");

        AuthModel authModel = new();
        authModel.Email = userFromDb.Email;
        authModel.Username = userFromDb.Username;
        authModel.Id = userFromDb.Id;

        return authModel;
    }
}