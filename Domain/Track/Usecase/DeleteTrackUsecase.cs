namespace MusicG.Domain.Track.Usecase;

public class DeleteTrackUsecase
{
    private ITrackRepository _trackRepository;

    public DeleteTrackUsecase(ITrackRepository rep)
    {
        _trackRepository = rep;
    }

    public Task Invoke(int id)
    {
        return _trackRepository.DeleteTrack(id);
    }
}