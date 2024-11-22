using AutoMapper;
using MusicG.Application.Auth.DTO;
using MusicG.Application.User.DTO;
using MusicG.Domain.Auth.Models;
using MusicG.Domain.User;

namespace MusicG.Application.Auth.Mapper;

public class ApplicationAuthMapper
{
    private readonly IMapper _mapper;

    public ApplicationAuthMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public AuthModel MapRegisterRequestToDomain(RequestRegisterAuthDto auth)
    {
        return _mapper.Map<AuthModel>(auth);
    }
    
    public AuthModel MapLoginRequestToDomain(RequestLoginAuthDto auth)
    {
        return _mapper.Map<AuthModel>(auth);
    }

    public ResponseAuthDto MapToResponse(AuthModel auth, string token)
    {
        ResponseAuthDto response = new()
        {
            User = _mapper.Map<ResponseUserDto>(auth),
            Token = token
        };
        return response;
    }
}