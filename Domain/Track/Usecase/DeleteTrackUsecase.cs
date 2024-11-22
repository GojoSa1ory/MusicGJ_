namespace MusicG.Domain.Track.Usecase;

public class DeleteTrackUsecase
{
    private TrackRepository _trackRepository;

    public DeleteTrackUsecase(TrackRepository rep)
    {
        _trackRepository = rep;
    }

    public Task Invoke(int id)
    {
        return _trackRepository.DeleteTrack(id);
    }
}