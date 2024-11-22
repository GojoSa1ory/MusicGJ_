using AutoMapper;
using MusicG.Domain.Genre.Models;
using MusicG.Infrastructure.database.entity;

namespace MusicG.Infrastructure.Mapper;

public interface InfGenreMapper
{
    GenreEntity mapToEntity(GenreModel genre);
    GenreModel mapToDomain (GenreEntity genre);
}

public class InfGenreMapperImpl: InfGenreMapper
{
    private readonly IMapper _mapper;

    public InfGenreMapperImpl(IMapper mapper)
    {
        _mapper = mapper;
    }

    public GenreEntity mapToEntity(GenreModel genre)
    {
        return _mapper.Map<GenreEntity>(genre);
    }

    public GenreModel mapToDomain(GenreEntity genre)
    {
        return _mapper.Map<GenreModel>(genre);
    }
}