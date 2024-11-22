using AutoMapper;
using MusicG.Domain.Track.Models;

public class TrackApplicationMapper {

    private readonly IMapper _mapper;

    public TrackApplicationMapper(IMapper mapper) {
        _mapper = mapper;
    }

    public TrackModelWithoutUser MapToDomain(RequestTrackDto track) {
        return _mapper.Map<TrackModelWithoutUser>(track);
    }

    public TrackModel MapToDomainFromUpdateRequest(RequestUpdateTrackDTO track) {
        return _mapper.Map<TrackModel>(track);
    }

    public ResponseTrackDto MapToResponse(TrackModel track) {
        return _mapper.Map<ResponseTrackDto>(track);
    }


}