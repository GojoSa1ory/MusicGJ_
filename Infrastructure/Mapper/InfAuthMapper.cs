using AutoMapper;
using MusicG.Domain.Auth.Models;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.Mapper;

public class InfAuthMapper
{
    private readonly IMapper _mapper;

    public InfAuthMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public AuthModel MapToDomain(UserEntity user)
    {
        return _mapper.Map<AuthModel>(user);
    }

    public UserEntity MapToEntity(AuthModel model)
    {
        return _mapper.Map<UserEntity>(model);
    }

}