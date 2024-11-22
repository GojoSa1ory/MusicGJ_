using MusicG.Domain.Track.Models;

namespace MusicG.Domain.Track.Usecase;

public class GetTracksUsecase
{
    private readonly TrackRepository _rep;

    public GetTracksUsecase(TrackRepository rep)
    {
        _rep = rep;
    }

    public Task<List<TrackModel>> Invoke()
    {
        return _rep.GetTracks();
    } 
}