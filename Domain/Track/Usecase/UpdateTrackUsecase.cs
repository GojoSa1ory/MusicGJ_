using MusicG.Domain.Track.Models;

public class UpdateTrackUsecase {

    private readonly ITrackRepository _rep;

    public UpdateTrackUsecase(ITrackRepository rep)
    {
        _rep = rep;
    }

    public Task<TrackModel> Invoke(int id, TrackModel track) {
        return _rep.UpdateTrack(id: id, track: track);
    }
}