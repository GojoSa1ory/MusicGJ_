using MusicG.Domain.Track.Models;

public class AddTrackUsecase {
    private readonly TrackRepository _rep;

    public AddTrackUsecase(TrackRepository track) {
        _rep = track;
    }

    public Task<TrackModel> Invoke(TrackModelWithoutUser track) {
        return _rep.AddTrack(track: track);
    }
}