using MusicG.Domain.Track.Models;

namespace MusicG.Domain.Track.Usecase;

public class GetTrackByNameUsecase
{
    private readonly ITrackRepository _repository;

    public GetTrackByNameUsecase(ITrackRepository repository)
    {
        _repository = repository;
    }

    public Task<List<TrackModel>> Invoke(string name)
    {
        return _repository.GetTrackByName(name);
    }
}