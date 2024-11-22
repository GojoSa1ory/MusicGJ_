using AutoMapper;

namespace MusicG.Application.User.Mapper;

public class ApplicationUserMapper
{
    private readonly IMapper _mapper;

    public ApplicationUserMapper(IMapper mapper)
    {
        _mapper = mapper;
    }
    

}