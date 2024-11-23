using AutoMapper;
using MusicG.Domain.Genre.Models;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.Mapper;

public interface INfGenreMapper
{
    GenreEntity MapToEntity(GenreModel genre);
    GenreModel MapToDomain (GenreEntity genre);
}

public class InfGenreMapperImpl: INfGenreMapper
{
    private readonly IMapper _mapper;

    public InfGenreMapperImpl(IMapper mapper)
    {
        _mapper = mapper;
    }

    public GenreEntity MapToEntity(GenreModel genre)
    {
        return _mapper.Map<GenreEntity>(genre);
    }

    public GenreModel MapToDomain(GenreEntity genre)
    {
        return _mapper.Map<GenreModel>(genre);
    }
}