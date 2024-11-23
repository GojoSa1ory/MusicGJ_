using MusicG.Domain.Track.Models;

namespace MusicG.Domain.Track.Usecase;

public class GetTracksUsecase
{
    private readonly ITrackRepository _rep;

    public GetTracksUsecase(ITrackRepository rep)
    {
        _rep = rep;
    }

    public Task<List<TrackModel>> Invoke()
    {
        return _rep.GetTracks();
    } 
}