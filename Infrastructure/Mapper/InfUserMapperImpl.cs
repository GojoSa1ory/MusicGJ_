using AutoMapper;
using MusicG.Domain.User;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.Mapper;

public interface InfUserMapper
{
    UserModel mapToDomain(UserEntity user);
    UserEntity mapToEntity(UserModel user);
}

public class InfUserMapperImpl: InfUserMapper
{

    private readonly IMapper _mapper;

    public InfUserMapperImpl(IMapper mapper)
    {
        _mapper = mapper;
    }


    public UserModel mapToDomain(UserEntity user)
    {
        return _mapper.Map<UserModel>(user);
    }

    public UserEntity mapToEntity(UserModel user)
    {
        return _mapper.Map<UserEntity>(user);
    }
}