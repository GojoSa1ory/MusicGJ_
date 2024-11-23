using MusicG.Domain.Track.Models;

public class GetTrackByIdUsecase {
    private readonly ITrackRepository _rep;

    public GetTrackByIdUsecase(ITrackRepository rep)
    {
        _rep = rep;
    }

    public Task<TrackModel> Invoke(int id) {
        return _rep.GetTrackById(id);
    }
}