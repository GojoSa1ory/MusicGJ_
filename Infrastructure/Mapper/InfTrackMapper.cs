using AutoMapper;
using MusicG.Domain.Genre.Models;
using MusicG.Domain.Track.Models;
using MusicG.Domain.User;
using MusicG.Infrastructure.database.entity;

public class InfTrackMapper {
    private readonly IMapper _mapper;

    public InfTrackMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TrackEntity MapToEntity(TrackModel track) {
        return _mapper.Map<TrackEntity>(track);
    }

    public TrackModel MapToDomainWithUser(TrackModelWithoutUser track, UserModel user, GenreModel genre) => new TrackModel
    {
        Id = track.Id,
        Name = track.Name,
        Track = track.Track,
        TrackImage = track.TrackImage,
        User = user,
        Genre = genre
    };

    public TrackModel MapToDomain(TrackEntity track) {
        return _mapper.Map<TrackModel>(track);
    }
}