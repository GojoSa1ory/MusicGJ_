using MusicG.Domain.Track.Models;

public class UpdateTrackUsecase {

    private readonly TrackRepository _rep;

    public UpdateTrackUsecase(TrackRepository rep)
    {
        _rep = rep;
    }

    public Task<TrackModel> Invoke(int id, TrackModel track) {
        return _rep.UpdateTrack(id: id, track: track);
    }
}