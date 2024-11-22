using MusicG.Domain.Track.Models;

public class GetTrackByIdUsecase {
    private readonly TrackRepository _rep;

    public GetTrackByIdUsecase(TrackRepository rep)
    {
        _rep = rep;
    }

    public Task<TrackModel> Invoke(int id) {
        return _rep.GetTrackById(id);
    }
}