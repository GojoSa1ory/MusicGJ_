using AutoMapper;
using MusicG.Domain.User;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.Mapper;

public interface INfUserMapper
{
    UserModel MapToDomain(UserEntity user);
    UserEntity MapToEntity(UserModel user);
}

public class InfUserMapperImpl: INfUserMapper
{

    private readonly IMapper _mapper;

    public InfUserMapperImpl(IMapper mapper)
    {
        _mapper = mapper;
    }


    public UserModel MapToDomain(UserEntity user)
    {
        return _mapper.Map<UserModel>(user);
    }

    public UserEntity MapToEntity(UserModel user)
    {
        return _mapper.Map<UserEntity>(user);
    }
}