using MusicG.Domain.Track.Models;

public class AddTrackUsecase {
    private readonly ITrackRepository _rep;

    public AddTrackUsecase(ITrackRepository track) {
        _rep = track;
    }

    public Task<TrackModel> Invoke(TrackModelWithoutUser track) {
        return _rep.AddTrack(track: track);
    }
}